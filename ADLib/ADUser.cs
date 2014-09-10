using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Reflection;
using DataMapper;

namespace ADLib
{
    public enum UserStates { New, Existing };

    /// <summary>
    /// Represents an AD User object, wraps an AD UserPrincipal
    /// </summary>
    public class ADUser : ADObject
    {
        UserPrincipal _sourceUser;
        ActiveDirectory _connection;
        IList<string> _groups;
        string _password = null;
        Boolean passwordChanged = false;
        Boolean _isNewUser = false;
        DEMapper mapper = null;
        List<string> DEFields = new List<string>();
        DirectoryEntry directoryEntry;
        DirectoryEntry parent;

        /// <summary>
        /// Create a new AD User on the given connection
        /// </summary>
        /// <param name="connection">The AD connection</param>
        public ADUser(ActiveDirectory connection)
            : this(connection, new UserPrincipal(connection.Context))
        {
            _groups = new List<string>() { };
            _isNewUser = true;
            this.UserState = UserStates.New;
        }

        /// <summary>
        /// Create an AD User from the given connection and UserPrincipal
        /// </summary>
        /// <param name="connection">The AD connection</param>
        /// <param name="user">An existing UserPrincipal object</param>
        public ADUser(ActiveDirectory connection, UserPrincipal user)
        {
            if (connection == null || user == null)
            {
                throw new NullReferenceException();
            }

            _sourceUser = user;
            _connection = connection;
            mapper = new DEMapper();
            DEFields.Add("manager");
            this.UserState = UserStates.Existing;

            foreach (System.Reflection.PropertyInfo property in this.GetType().GetProperties())
            {
                DEFieldAttribute tag= property.GetCustomAttributes(typeof(DEFieldAttribute),true).FirstOrDefault() as DEFieldAttribute;

                if (tag != null)
                {
                    DEFields.Add(tag.Name!=null?tag.Name:property.Name);
                }
            }

            if (user.Name != null)
            {
                _groups = new List<string>(_sourceUser.GetGroups(connection.GlobalContext).Select(item => item.Name));
            }

            this.Initialize(_sourceUser);

            if (_sourceUser.DisplayName != null)
            {
                directoryEntry = _sourceUser.GetUnderlyingObject() as DirectoryEntry;
                directoryEntry.RefreshCache(DEFields.ToArray<string>());
                mapper.Copy(directoryEntry, this);
            }

            string ldap=String.Format("LDAP://{0}/{1}", connection.Name, connection.Container);
            parent = new DirectoryEntry(ldap, connection.User, connection.Password);

        }

        /// <summary>
        /// Synchronize groups between the local ADUser object and the AD server record
        /// </summary>
        private void Sync_Groups()
        {
            //Sync groups
            HashSet<string> oldGroups = new HashSet<string>(_sourceUser.GetGroups(_connection.GlobalContext).Select(item => item.Name));
            HashSet<string> newGroups = new HashSet<string>(this.Groups);

            //Add new groups
            foreach (String groupName in newGroups.Where(item => !oldGroups.Contains(item)))
            {
                addToGroup(groupName);
            }

            if (newGroups.Count > 0)
            {
                //Remove missing groups
                foreach (String groupName in oldGroups.Where(item => !newGroups.Contains(item)))
                {
                    removeFromGroup(groupName);
                }
            }
            _groups = new List<string>(_sourceUser.GetGroups(_connection.GlobalContext).Select(item => item.Name));

        }

        /// <summary>
        /// Save the local ADUser data to the remote server
        /// </summary>
        public void Save()
        {
            if (isSaveable)
            {
                //Set password
                if (passwordChanged)
                {
                    _sourceUser.SetPassword(_password);
                    passwordChanged = false;
                }

                if (_sourceUser.Name == null || _sourceUser.DisplayName == null)
                {
                    _sourceUser.Name = GivenName + " " + Surname;
                    _sourceUser.DisplayName = _sourceUser.Name;

                }
                Boolean wasNewUser = _isNewUser;

                try
                {
                    _sourceUser.Save();

                    //Save data to AD
                    if (_isNewUser)
                    {
                        directoryEntry = _sourceUser.GetUnderlyingObject() as DirectoryEntry;
                    }
                    _isNewUser = false;
                }
                catch (PrincipalExistsException ex)
                {
                    throw new DuplicateUser(ex.Message);
                }

                Sync_Groups();

                //Have to reload the UserPrincipal to get the DirectoryEntry
                UserPrincipal newSourceUser = _connection.GetUserBySid(_sourceUser.Sid);

                //if (wasNewUser)
                //{

                    if (newSourceUser == null)
                    {
                        string msg = "Couldn't reload user: " + _sourceUser.DisplayName;

                        throw new InvalidOperationException(msg);
                    }
                    _sourceUser = newSourceUser;
                //}

                if (directoryEntry != null)
                {
                    directoryEntry.Close();
                }

                directoryEntry = _sourceUser.GetUnderlyingObject() as DirectoryEntry;

                directoryEntry.Options.SecurityMasks = SecurityMasks.Dacl;

                //Copy local attributes to directory entry
                //directoryEntry.RefreshCache(DEFields.ToArray<string>());
                mapper.Copy(this, directoryEntry);

                if ((this.Manager != null) && (!this.Manager.DistinguishedName.Equals(directoryEntry.Properties["manager"].Value)))
                {
                    if (directoryEntry.Properties.Contains("manager"))
                    {
                        directoryEntry.Properties["manager"].Value = this.Manager.DistinguishedName;
                    }
                    else
                    {
                        directoryEntry.Properties["manager"].Add(this.Manager.DistinguishedName);
                    }
                }

                if (DisplayName != directoryEntry.Properties["cn"].Value as string)
                {
                    directoryEntry.Rename("CN=" + DisplayName);
                }


                try
                {
                    directoryEntry.CommitChanges();
                }
                catch (DirectoryServicesCOMException ex)
                {
                    System.Diagnostics.Debug.Write(ex.Message + " - " + ex.StackTrace);
                    throw new ADException(String.Format("DirectoryServicesCOMException {0}", ex.Message), ex);
                }

                if (this.HideFromAddressLists)
                {
                    try
                    {
                        if (!directoryEntry.Properties.Contains("msExchHideFromAddressLists"))
                        {
                            directoryEntry.Properties["msExchHideFromAddressLists"].Add("TRUE");
                        }
                        else
                        {
                            directoryEntry.Properties["msExchHideFromAddressLists"].Value="TRUE";
                        }

                        directoryEntry.CommitChanges();
                    }
                    catch (DirectoryServicesCOMException)
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Add the ADUser to a group
        /// </summary>
        /// <param name="groupName">The name of the group to which the user should be added</param>
        public void addToGroup(string groupName)
        {
            try
            {
                _connection.AddUserToGroup(_sourceUser, groupName);
            }
            catch (Exception ex)
            {
                string msg = String.Format("Error adding user '{0}' to group '{1}': '{2}'", this.DisplayName, groupName, ex.Message);
                Console.WriteLine(msg);
                throw new ADException(msg, ex);
            }
        }

        /// <summary>
        /// Remove the ADUser from a group
        /// </summary>
        /// <param name="groupName">The name of the group from which the ADUser should be removed</param>
        public void removeFromGroup(string groupName)
        {
            try
            {
                _connection.RemoveUserFromGroup(_sourceUser, groupName);
            }
            catch (Exception ex)
            {
                string msg = String.Format("Error removing user '{0}' from group '{1}': '{2}'", this.DisplayName, groupName, ex.Message);
                Console.WriteLine(msg);
                throw new ADException(msg, ex);
            }
        }

        public IEnumerable<ADUser> find()
        {
            List<ADUser> results = new List<ADUser>();

            return results;
        }

        public void MoveTo(params string[] OUs)
        {
            DirectoryEntry node = null;
            string container = _connection.Container;

            string connString = string.Format("LDAP://{0}/{1}", _connection.Name, container);
            node = new DirectoryEntry(connString, _connection.User, _connection.Password);
            
            foreach (string name in OUs.Reverse().Select(i=>"OU=" + i))
            {
                DirectoryEntry child=null;

                try
                {
                    child = node.Children.Find(name, "OrganizationalUnit");
                }
                catch (DirectoryServicesCOMException)
                {
                    child = node.Children.Add(name, "OrganizationalUnit");
                    child.CommitChanges();
                }
                node.Close();
                node = child;
            }
            
            try
            {
                if (isNewUser)
                {
                    this.Save();
                }

                this.directoryEntry.MoveTo(node, this.directoryEntry.Name);
                this.directoryEntry.CommitChanges();
            }
            catch (Exception ex)
            {
                string msg = String.Format("Error moving user '{0}' to location '{1}': '{2}'", this.DisplayName, node.Name, ex.Message);
                Console.WriteLine(msg);
                throw new ADException(msg, ex);
            }

        }

        public ActiveDirectory Connection { get { return this._connection; } }

        /// <summary>
        /// The object's AD GivenName field
        /// </summary>
        [DEField("givenName")]
        public String GivenName { get; set; }

        /// <summary>
        /// The object's AD Surname field
        /// </summary>
        [DEField("sn")]
        public String Surname {get;set;}

        [DEField("middleName")]
        public String MiddleName { get;set; }

        [DEField("employeeID")]
        public string EmployeeId {get;set; }

        /// <summary>
        /// The object's AD EmailAddress field
        /// </summary>
        [DEField("mail")]
        public String EmailAddress { get;set; }

        /// <summary>
        /// The object's AD VoiceTelephoneNumber field
        /// </summary>
        [DEField("telephoneNumber")]
        public String VoiceTelephoneNumber { get;set; }

        /// <summary>
        /// The object's AD Enabled field
        /// </summary>
        public bool? Enabled
        {
            get { return _sourceUser.Enabled; }
            set
            {
                _sourceUser.Enabled = value;
            }
        }

        [DEField("company")]
        public String Company { get; set; }

        [DEField("ipPhone")]
        public String IPPhone { get;  set; }

        [DEField("mobile")]
        public String Mobile { get; set; }

        [DEField("pager")]
        public String Pager { get; set; }

        [DEField("physicalDeliveryOfficeName")]
        public String PhysicalDeliveryOfficeName { get; set; }

        [DEField("streetAddress")]
        public String StreetAddress { get; set; }

        [DEField("l")]
        public String City { get; set; }

        [DEField("st")]
        public String State { get; set; }

        [DEField("postalCode")]
        public String PostalCode { get; set; }

        [DEField("c")]
        public String Country { get; set; }

        [DEField("employeeType")]
        public String EmployeeType { get; set; }

        [DEField("employeeNumber")]
        public String EmployeeNumber { get; set; }

        [DEField("title")]
        public String Title { get; set; }

        [DEField("department")]
        public String Department { get; set; }

        [DEField("homeDirectory")]
        public String HomeDirectory { get; set; }

        [DEField("homeDrive")]
        public String HomeDrive { get; set; }

        //[DEField("msExchHideFromAddressLists")]
        //[DEField("showInAddressBook")]
        public Boolean HideFromAddressLists { get; set; }

        public String DistinguishedName
        {
            get
            {
                if (!directoryEntry.Properties.Contains("distinguishedName"))
                {
                    DEFields.Add("distinguishedName");
                    directoryEntry.RefreshCache(DEFields.ToArray());
                }

                return directoryEntry.Properties["distinguishedName"].Value.ToString();
            }
        }

        //[DEField("cn")]
        public String FullName
        {
            get { return DisplayName; }
            set { DisplayName = value; }
        }

        private ADUser _Manager { get; set; }

        /// <summary>
        /// Manager user object lookup
        /// </summary>
        public ADUser Manager {
            get
            {
                if ((this._Manager == null || _Manager.DistinguishedName != this.ManagerName) && !String.IsNullOrEmpty(this.ManagerName))
                {
                    string cn = this.ManagerName.Split(',').Where(i => i.StartsWith("CN=")).First();

                    if (!string.IsNullOrEmpty(cn))
                    {
                        cn = cn.Substring(3);

                        UserPrincipal manager = (UserPrincipal)this.Connection.Find(cn).FirstOrDefault();

                        if (manager != null)
                        {
                            this._Manager = new ADUser(this.Connection, manager);
                        }
                    }
                }

                return this._Manager;
            }

            set
            {
                this._Manager = value;

                if (this._Manager != null)
                {
                    this.ManagerName = this._Manager.DistinguishedName;
                }
                else
                {
                    this.ManagerName = null;
                }
            }
        }

        /// <summary>
        /// Manager's distinguished name
        /// </summary>
        [DEField("manager")]
        public string ManagerName { get; set; }

        /// <summary>
        /// User Principal Name
        /// </summary>
        [DEField("userPrincipalName")]
        public string UserPrincipalName { get; set; }

        public IEnumerable<String> Fields
        {
            get { return this.DEFields; }
        }

        //public string EmployeeId
        //{
        //    get { return _sourceUser; }
        //    set { _sourceUser.EmployeeId = value == "" ? null : value; }
        //}


        /// <summary>
        /// The locally stored value of the AD user password.  A value will only be present if it has
        /// been locally written.  It will be saved to the remote password when Save() is called.
        /// </summary>
        public String Password
        {
            get { return _password; }
            set
            {
                _password = value == "" ? null : value;
                passwordChanged = true;
            }
        }

        /// <summary>
        /// True if the ADUser object is new, and has not been saved remotely
        /// </summary>
        public Boolean isNewUser
        {
            get { return _isNewUser; }
        }

        /// <summary>
        /// True if the object is either not new, or if the Password, GivenName, Surname, and SAMAccountname have been set
        /// </summary>
        public Boolean isSaveable
        {
            get
            { return !isNewUser || (Password != null && GivenName != null && Surname != null && SamAccountName != null); }
        }

        /// <summary>
        /// Flags whether the ADUser is Deleteable from the remote server, i.e. if it's not new
        /// </summary>
        public Boolean isDeleteable
        {
            get
            { return !isNewUser; }
        }

        /// <summary>
        /// Returns a list of the names of all groups to which the ADUser belongs
        /// </summary>
        public IList<string> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        public UserStates UserState { get; set; }
    }
}
