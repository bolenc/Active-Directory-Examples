using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
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
    
    public class DuplicateUser : Exception
    {
        public DuplicateUser(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// An exception to wrap AD exceptions
    /// </summary>
    public class ADException : Exception
    {
        public Exception Wrapped { get; set; }

        public ADException(string message =null, Exception wrapped = null) : base(message)
        {
            Wrapped = wrapped;
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
        [DEField("description")]
        public String Description { get;set; }

        /// <summary>
        /// The object's AD DisplayName field
        /// </summary>
        [DEField("displayName")]
        public String DisplayName { get;set; }

        /// <summary>
        /// The object's AD SAMAccountName field
        /// </summary>
        [DEField("sAMAccountName")]
        public String SamAccountName
        {
            get { return _sourceItem.SamAccountName; }
            set
            {
                _sourceItem.SamAccountName = value == "" ? null : value;
            }
        }

        public override String ToString()
        {
            return DisplayName;
        }
    }
}
