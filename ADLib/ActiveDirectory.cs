using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Configuration;

namespace ADLib
{
    /// <summary>
    /// Describes the type of active directory object
    /// </summary>
    public enum ADObjectType { User, Group, All };

    /// <summary>
    /// This class encapsulates an Active Directory connection, and handles common tasks
    /// </summary>
    public class ActiveDirectory
    {
        PrincipalContext _Context = null;
        string _Container;
        string _Name;
        string _userid;
        string _password;
        /// <summary>
        /// Create an Active Directory connection
        /// </summary>
        public ActiveDirectory(string container, string name, string userid, string password)
        {
            _Container = container;
            _Name = name;
            _userid = userid;
            _password = password;
            _Context = new PrincipalContext(ContextType.Domain, Name, Container, userid, password);
        }

        /// <summary>
        /// The context in which this connection is operating
        /// </summary>
        public PrincipalContext Context
        {
            get { return _Context;}
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
        public UserPrincipal GetUser(string userID)
        {
            return UserPrincipal.FindByIdentity(Context, userID);
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
        public GroupPrincipal GetGroup(string groupName)
        {
            return GroupPrincipal.FindByIdentity(Context, groupName);
        }

        /// <summary>
        /// Removes the user from the specified group
        /// </summary>
        /// <param name="adUser">User to remove</param>
        /// <param name="groupName">Group from which the user should be removed</param>
        public void RemoveUserFromGroup(UserPrincipal adUser, string groupName)
        {
            GroupPrincipal g = GroupPrincipal.FindByIdentity(Context, groupName);
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
            GroupPrincipal g = GroupPrincipal.FindByIdentity(Context, groupName);
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
            GroupPrincipal g = new GroupPrincipal(Context, groupName);
            
            g.Save();

            //Add new group as a subgroup of Domain Users
            if (isUserGroup)
            {
                GroupPrincipal users = GroupPrincipal.FindByIdentity(Context, "Domain Users");
                users.Members.Add(g);
                users.Save();
            }

            return g;
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

            //For each search result...
            foreach (SearchResult result in searcher.FindAll())
            {
                //Add a UserPrincipal object to the result list for this ID
                results.Add(GetUser((string)result.GetDirectoryEntry().Properties["SAMAccountName"].Value));
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
    }
}
