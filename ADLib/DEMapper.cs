using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

using DataMapper;

namespace ADLib
{
    /// <summary>
    /// Tags an AD Directory Entry attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DEFieldAttribute : Attribute, INamed
    {
        public string Name { get; set; }

        public DEFieldAttribute(string name)
        {
            Name = name;
        }
    }

    class DEMapper : DataMapper<DEFieldAttribute, ADUser, DirectoryEntry, String>
    {
        public DEMapper() : base() { }

        protected override object GetValue(string piece, DirectoryEntry from)
        {
            return from.Properties[piece].Value;
        }

        protected override void SetValue(string piece, DirectoryEntry to, object value)
        {
            object newValue=((string)value=="") ? null : value;

            if (to.Properties.Contains(piece))
            {
                if (!to.Properties[piece].Value.Equals(newValue))
                {
                    to.Properties[piece].Value = newValue;
                }
            }
            else if (newValue != null)
            {
                to.Properties[piece].Add(newValue);
            }
        }

        protected override void GetMapping()
        {
            Dictionary<System.Reflection.PropertyInfo, String> results =
                new Dictionary<System.Reflection.PropertyInfo, String>();

            foreach (System.Reflection.PropertyInfo property in typeof(ADUser).GetProperties())
            {
                string tagName = GetTagName(property);

                if (tagName != null)
                {
                    results[property] = tagName;
                }
            }

            mapping = results;
        }
    }
}
