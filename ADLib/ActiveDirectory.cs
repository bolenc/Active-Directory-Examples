using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Configuration;
using System.Collections;

namespace ADLib
{
    /// <summary>
    /// Describes the type of active directory object
    /// </summary>
    public enum ADObjectType { User, Group, All };

    public abstract class ADCriteria
    {
        public ADCriteria() {}
        public abstract override string ToString();

        public virtual AndCriteria And(ADCriteria other)
        {
            return new AndCriteria() { this, other };
        }

        public virtual OrCriteria Or(ADCriteria other)
        {
            return new OrCriteria() { this, other };
        }
    }

    public class NullCriteria : ADCriteria
    {
        public override AndCriteria And(ADCriteria other)
        {
            return new AndCriteria() { other };
        }

        public override OrCriteria Or(ADCriteria other)
        {
            return new OrCriteria() { other };
        }
        public override string ToString() { return ""; }
    }

    public class BaseCriteria : ADCriteria
    {
        public BaseCriteria(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public override string ToString()
        { 
            string result="";

            if ((name != "") && (value != ""))
            {
                result = string.Format("({0}={1})", name, value);
            }

            return result;
        }

        public string name { get; set; }
        public string value { get; set; }
    }

    public abstract class CompositeCriteria : ADCriteria, IEnumerable
    {
        protected List<ADCriteria> contents;

        public CompositeCriteria()
        {
            contents = new List<ADCriteria>();
        }

        public virtual void Add(ADCriteria item) { contents.Add(item); }

        IEnumerator IEnumerable.GetEnumerator() { return (IEnumerator)GetEnumerator(); }
        public IEnumerator<ADCriteria> GetEnumerator() { return contents.GetEnumerator(); }

    }
    public class AndCriteria : CompositeCriteria
    {
        public AndCriteria() : base()
        {
        }

        public override string ToString()
        {
            string result = string.Join("", this.contents.Select(i => i.ToString()));

            if (this.contents.Count > 1)
            {
                result = string.Format("(&{0})", result);
            }

            return result;
        }
    }

    public class OrCriteria : CompositeCriteria
    {
        public OrCriteria() : base()
        {
        }

        public override string ToString()
        {
            string result = string.Join("", this.contents.Select(i=>i.ToString()));

            if (this.contents.Count > 1)
            {
                result = string.Format("(|{0})", result);
            }

            return result;
        }
    }

    /// <summary>
    /// This class encapsulates an Active Directory connection, and handles common tasks
    /// </summary>
    public class ActiveDirectory
    {
        PrincipalContext _Context = null;
        PrincipalContext _GlobalContext = null;
        string _Container;
        string _GlobalContainer;
        string _Name;
        string _userid;
        string _password;
        /// <summary>
        /// Create an Active Directory connection
        /// </summary>
        public ActiveDirectory(string container, string name, string userid, string password)
        {
            _Container = container;
            _GlobalContainer = GetGlobalContainer(container);
            _Name = name;
            _userid = userid;
            _password = password;
            _Context = new PrincipalContext(ContextType.Domain, Name, Container, userid, password);
            _GlobalContext = new PrincipalContext(ContextType.Domain, Name, _GlobalContainer, userid, password);
        }

        private string GetGlobalContainer(string container)
        {
            string result = "";
            
            IEnumerable<string> pairs=container.Split(",".ToCharArray()).Select(i=>i.Split("=".ToCharArray())).Where(i=>i[0].ToLower().Trim()!="ou").Select(i=>string.Join("=",i));
            result = string.Join(",", pairs);
            return result;
        }
        /// <summary>
        /// The context in which this connection is operating
        /// </summary>
        public PrincipalContext Context
        {
            get { return _Context;}
        }
        /// <summary>
        /// The global context containing the one in which this connection is operating
        /// </summary>
        public PrincipalContext GlobalContext
        {
            get { return _GlobalContext; }
        }

        /// <summary>
        /// The name of the AD server
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// The AD Container for this connection
        /// </summary>
        public string Container
        {
            get { return _Container; }
            set { _Container = value; }
        }

        /// <summary>
        /// Returns the user with the specified ID or null if not found
        /// </summary>
        /// <param name="userID">ID of the user</param>
        /// <returns></returns>
        public UserPrincipal GetUser(string userID, PrincipalContext context=null)
        {
            //TODO: Handle MultipleMatchesException
            return UserPrincipal.FindByIdentity(context ?? Context, userID);
        }

        /// <summary>
        /// Returns the user with the specified ID or null if not found
        /// </summary>
        /// <param name="userID">ID of the user</param>
        /// <returns></returns>
        public UserPrincipal GetUserByGuid(Guid guid, PrincipalContext context = null)
        {
            return UserPrincipal.FindByIdentity(context ?? Context, IdentityType.Guid, guid.ToString());
        }

        public UserPrincipal GetUserBySid(object Sid)
        {
            BaseCriteria query = new BaseCriteria("objectSid", Sid.ToString());

            return Find(query).FirstOrDefault() as UserPrincipal;
        }

        /// <summary>
        /// Returns true if the user is in the specified group
        /// </summary>
        /// <param name="adUser">The user</param>
        /// <param name="groupName">The ID of the group to check for membership</param>
        /// <returns></returns>
        public bool IsInGroup(UserPrincipal adUser, string groupName)
        {
            GroupPrincipal g = GroupPrincipal.FindByIdentity(Context, groupName);
            return adUser.IsMemberOf(g);
        }

        /// <summary>
        /// Get the group with the specified id or null if not found
        /// </summary>
        /// <param name="groupName">ID of the group</param>
        /// <returns></returns>
        public GroupPrincipal GetGroup(string groupName, PrincipalContext context=null)
        {
            //TODO: Handle MultipleMatchesException
            return GroupPrincipal.FindByIdentity(context??_GlobalContext, groupName);
        }

        /// <summary>
        /// Get the group with the specified guid or null if not found
        /// </summary>
        /// <param name="groupName">GUID of the group</param>
        /// <returns></returns>
        public GroupPrincipal GetGroupByGuid(Guid guid, PrincipalContext context = null)
        {
            return GroupPrincipal.FindByIdentity(context ?? _GlobalContext, IdentityType.Guid, guid.ToString());
        }

        /// <summary>
        /// Removes the user from the specified group
        /// </summary>
        /// <param name="adUser">User to remove</param>
        /// <param name="groupName">Group from which the user should be removed</param>
        public void RemoveUserFromGroup(UserPrincipal adUser, string groupName)
        {
            GroupPrincipal g = GroupPrincipal.FindByIdentity(_GlobalContext, groupName);
            g.Members.Remove(adUser);
            g.Save();
        }

        /// <summary>
        /// Adds the user to the specified group
        /// </summary>
        /// <param name="adUser">User to add</param>
        /// <param name="groupName">Group to which the user should be added</param>
        public void AddUserToGroup(UserPrincipal adUser, string groupName)
        {
            GroupPrincipal g = GetOrCreate(groupName);

            g.Members.Add(adUser);
            g.Save();
        }

        /// <summary>
        /// Creates a new group
        /// </summary>
        /// <param name="groupName">The name of the new group</param>
        /// <param name="isUserGroup">If true (default), the new group will be made a subgroup of Domain Users</param>
        /// <returns></returns>
        public GroupPrincipal CreateGroup(string groupName, Boolean isUserGroup=true)
        {
            GroupPrincipal g = new GroupPrincipal(_GlobalContext, groupName);
            
            g.Save();

            //Add new group as a subgroup of Domain Users
            //if (isUserGroup)
            //{
            //    GroupPrincipal users = GetOrCreate("Domain Users");
            //    users.Members.Add(g);
            //    users.Save();
            //}

            return g;
        }

        public GroupPrincipal GetOrCreate(string groupName, Boolean isUserGroup = true)
        {
            GroupPrincipal g = GroupPrincipal.FindByIdentity(_GlobalContext, groupName);

            if (g == null)
            {
                g = CreateGroup(groupName, isUserGroup);
            }

            return g;
        }

        public Principal GetPrincipal(SearchResult item)
        {
            Principal result = null;
            DirectoryEntry entry = item.GetDirectoryEntry();
            //PrincipalContext context = new PrincipalContext(ContextType.Domain,entry.
            switch (entry.SchemaClassName)
            {
                case "user":
                    result = GetUserByGuid(entry.Guid);
                    break;
                case "group":
                case "collection":
                    result = GetGroupByGuid(entry.Guid);
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// Performs a search on the current connection using the given query string (NOTE: Only users currently work)
        /// </summary>
        /// <param name="query">The query string</param>
        /// <param name="objectType">What objects to search for (defaults to User)</param>
        /// <returns>IEnumerable of the AD items found</returns>
        public IEnumerable<Principal> Find(string query, ADObjectType objectType = ADObjectType.User)
        {
            List<Principal> results = new List<Principal>();

            //Get an 'entry' for the directory we want
            DirectoryEntry entry = new DirectoryEntry(String.Format("LDAP://{0}", _Name),
                                                        _userid,
                                                        _password);

            //Create a 'searcher'
            DirectorySearcher searcher = new DirectorySearcher(entry);
            searcher.Filter = String.Format("(&(objectClass=user)(|(cn={0})(sAMAccountName={0})))", query);
            
            searcher.PropertiesToLoad.Clear();
            searcher.PropertiesToLoad.Add("cn");
            searcher.PageSize = 250;

            //For each search result...
            foreach (SearchResult result in searcher.FindAll())
            {
                Principal item = GetPrincipal(result);

                if (item != null)
                {
                    //Add a UserPrincipal object to the result list for this ID
                    results.Add(item);
                }
            }

            return results;
        }

        public IEnumerable<Principal> Find(ADCriteria criteria=null, ADObjectType objectType = ADObjectType.User)
        {
            List<Principal> results = new List<Principal>();
            ADCriteria query;

            //Get an 'entry' for the directory we want
            DirectoryEntry entry = new DirectoryEntry(String.Format("LDAP://{0}", _Name),
                                                        _userid,
                                                        _password);
            
            //Create a 'searcher'
            DirectorySearcher searcher = new DirectorySearcher(entry);

            if (criteria == null)
            {
                criteria = new NullCriteria();
            }

            if (objectType== ADObjectType.User)
            {
                query=criteria.And(new BaseCriteria("objectClass","user"));
            }
            else if (objectType == ADObjectType.Group)
            {
                query=criteria.And(new BaseCriteria("objectClass","group"));
            }
            else
            {
                query=criteria;
            }

            searcher.Filter = query.ToString();
            searcher.PropertiesToLoad.Clear();
            searcher.PropertiesToLoad.Add("cn");
            searcher.PageSize = 250;

            //For each search result...
            foreach (SearchResult result in searcher.FindAll())
            {
                Principal item=GetPrincipal(result);

                if (item != null)
                {
                    //Add a UserPrincipal object to the result list for this ID
                    results.Add(item);
                }
            }
            

            return results;
        }

        /// <summary>
        /// Writes debug statements to the output window
        /// </summary>
        /// <param name="message"></param>
        private static void SysMessage(string message)
        {
            System.Diagnostics.Debug.WriteLine(DateTime.UtcNow + " - " + message);
        }

        public string ConnectionStringFor(string item="")
        {
            return string.Format("LDAP://{0}/{1}", Name, (item != "" ? item + "," : "") + Container);
        }

        public string User
        {
            get { return _userid; }
        }

        public string Password
        {
            get { return _password; }
        }

        public string ConnectionString
        {
            get { return ConnectionStringFor(); }
        }
    }
}
