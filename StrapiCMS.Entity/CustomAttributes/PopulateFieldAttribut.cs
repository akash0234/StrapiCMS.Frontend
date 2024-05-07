using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PopulateFieldAttribute : Attribute
    {
        public string Value { get; }

        public PopulateFieldAttribute(string value)
        {
            Value = value;
        }
    }

}

