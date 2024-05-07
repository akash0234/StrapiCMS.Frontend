using StrapiCMS.Entity.CustomAttributes;
using StrapiCMS.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrapiCMS.Common.Helper
{
    public static class PopulateFieldExtensions
    {
        public static string GetStringValue(this PopulateFields field)
        {
            var type = field.GetType();
            var name = Enum.GetName(type, field);
            if (name != null)
            {
                var fieldInfo = type.GetField(name);
                if (fieldInfo != null)
                {
                    var attr = Attribute.GetCustomAttribute(fieldInfo, typeof(PopulateFieldAttribute)) as PopulateFieldAttribute;
                    if (attr != null)
                    {
                        return attr.Value;
                    }
                }
            }
            throw new InvalidOperationException("No string value for this populate field");
        }
    }

}
