using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace ADLib
{

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
