using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices.AccountManagement;

namespace ADLib
{
    //This file contains classes that wrap Active Directory objects from
    // System.DirectoryServices.AccountManagement.  They are meant to
    // simplify the interface, eliminating the need for function calls,
    // and homogenizing the API to either String or List<String> parameters.
    // This makes them easily compatible with Databindings

    /// <summary>
    /// Exception raised when an Active Directory object is not found in a search
    /// </summary>
    public class ADNotFound : Exception
    {
        public ADNotFound(string message)
            : base(message)
        {
        }
    }

    /// <summary>
    /// Represents a generic AD Principal object
    /// </summary>
    public abstract class ADObject
    {
        Principal _sourceItem;
        /// <summary>
        /// Create an ADObject
        /// </summary>
        protected ADObject()
        {
            _sourceItem = null;
        }

        /// <summary>
        /// Initialize an AD object with a Principal
        /// </summary>
        /// <param name="item">a Principal object from the AccountManagement library</param>
        protected void Initialize(Principal item)
        {
            _sourceItem = item;
        }

        /// <summary>
        /// Delete the ADObject from the AD server
        /// </summary>
        public void Delete()
        {
            _sourceItem.Delete();
        }

        /// <summary>
        /// The object's AD description field
        /// </summary>
        public String Description
        {
            get { return _sourceItem.Description; }
            set { _sourceItem.Description = value == "" ? null : value; }
        }

        /// <summary>
        /// The object's AD DisplayName field
        /// </summary>
        public String DisplayName
        {
            get { return _sourceItem.DisplayName; }
            set { _sourceItem.DisplayName = value == "" ? null : value; }
        }

        /// <summary>
        /// The object's AD SAMAccountName field
        /// </summary>
        public String SamAccountName
        {
            get { return _sourceItem.SamAccountName; }
            set
            {
                _sourceItem.SamAccountName = value == "" ? null : value;
            }
        }
    }

    /// <summary>
    /// Represents an AD User object, wraps an AD UserPrincipal
    /// </summary>
    public class ADUser : ADObject
    {
        UserPrincipal _sourceUser;
        ActiveDirectory _connection;
        List<string> _groups;
        string _password = null;
        Boolean passwordChanged = false;
        Boolean _isNewUser = false;

        /// <summary>
        /// Create a new AD User on the given connection
        /// </summary>
        /// <param name="connection">The AD connection</param>
        public ADUser(ActiveDirectory connection)
            : this(connection, new UserPrincipal(connection.Context))
        {
            _groups = new List<string>() { "Domain Users" };
            _isNewUser = true;
        }

        /// <summary>
        /// Create an AD User from the given connection and UserPrincipal
        /// </summary>
        /// <param name="connection">The AD connection</param>
        /// <param name="user">An existing UserPrincipal object</param>
        public ADUser(ActiveDirectory connection, UserPrincipal user)
        {
            if (connection == null || user==null)
            {
                throw new NullReferenceException();
            }

            _sourceUser = user;
            _connection = connection;

            if (user.Name != null)
            {
                _groups = new List<string>(_sourceUser.GetGroups(_connection.Context).Select(item => item.Name));
            }

            this.Initialize(_sourceUser);
        }

        /// <summary>
        /// Synchronize groups between the local ADUser object and the AD server record
        /// </summary>
        private void Sync_Groups()
        {
            //Sync groups
            List<string> oldGroups = new List<string>(_sourceUser.GetGroups(_connection.Context).Select(item => item.Name));

            //Add new groups
            foreach (String groupName in _groups.Where(item => !oldGroups.Contains(item)))
            {
                addToGroup(groupName);
            }

            //Remove missing groups
            foreach (String groupName in oldGroups.Where(item => !_groups.Contains(item)))
            {
                removeFromGroup(groupName);
            }

            _groups = new List<string>(_sourceUser.GetGroups(_connection.Context).Select(item => item.Name));

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

                if (_sourceUser.Name == null)
                {
                    _sourceUser.Name = GivenName + " " + Surname;
                }

                //Save data to AD
                _sourceUser.Save();
                _isNewUser = false;

                Sync_Groups();
            }
        }

        /// <summary>
        /// Add the ADUser to a group
        /// </summary>
        /// <param name="groupName">The name of the group to which the user should be added</param>
        public void addToGroup(string groupName)
        {
            _connection.AddUserToGroup(_sourceUser, groupName);
        }

        /// <summary>
        /// Remove the ADUser from a group
        /// </summary>
        /// <param name="groupName">The name of the group from which the ADUser should be removed</param>
        public void removeFromGroup(string groupName)
        {
            _connection.RemoveUserFromGroup(_sourceUser, groupName);
        }

        /// <summary>
        /// The object's AD GivenName field
        /// </summary>
        public String GivenName
        {
            get { return _sourceUser.GivenName; }
            set { _sourceUser.GivenName = value == "" ? null : value; }
        }

        /// <summary>
        /// The object's AD Surname field
        /// </summary>
        public String Surname
        {
            get { return _sourceUser.Surname; }
            set { _sourceUser.Surname = value == "" ? null : value; }
        }

        /// <summary>
        /// The object's AD EmailAddress field
        /// </summary>
        public String EmailAddress
        {
            get { return _sourceUser.EmailAddress; }
            set { _sourceUser.EmailAddress = value == "" ? null : value; }
        }

        /// <summary>
        /// The object's AD VoiceTelephoneNumber field
        /// </summary>
        public String VoiceTelephoneNumber
        {
            get { return _sourceUser.VoiceTelephoneNumber; }
            set { _sourceUser.VoiceTelephoneNumber = value == "" ? null : value; }
        }

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
            { return ! isNewUser || (Password != null && GivenName != null && Surname != null && SamAccountName != null); }
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
        public List<string> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }
    }

    /// <summary>
    /// Represents an AD group.  Wrapper around a GroupPrincipal object
    /// </summary>
    public class ADGroup : ADObject
    {
        ActiveDirectory _connection;
        GroupPrincipal _source;
        public ADGroup(ActiveDirectory connection, GroupPrincipal source)
        {
            _connection = connection;
            _source = source;
        }
    }

    /// <summary>
    /// Factory for creating ADObjects
    /// </summary>
    public class ADObjectFactory
    {
        ActiveDirectory _connection;

        /// <summary>
        /// Create an ADOBjectFactory for the given connection
        /// </summary>
        /// <param name="connection">An Active Directory connection</param>
        public ADObjectFactory(ActiveDirectory connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Converts a Princpal object (or anything descended from one) into the appropriate AD*** object.
        ///   UserPrincipal  -> ADUser
        ///   GroupPrincipal -> ADGroup
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public ADObject toADObject(Principal source)
        {
            ADObject result = null;

            if (source is UserPrincipal)
            {
                result = new ADUser(_connection, (UserPrincipal)source);
            }
            else if (source is GroupPrincipal)
            {
                result = new ADGroup(_connection, (GroupPrincipal)source);
            }
            else
            {
                throw new NotImplementedException("This type of principal has not yet been implemented");
            }

            return result;
        }
    }

}
