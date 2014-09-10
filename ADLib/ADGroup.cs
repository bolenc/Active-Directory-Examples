using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace ADLib
{
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
}
