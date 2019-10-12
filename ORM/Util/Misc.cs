using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Attributes;

namespace ORM.Util
{
    public static class Misc
    {
        public static string GetTableName(this Type type)
        {
            TableNameAttribute attribute = type.GetCustomAttributes(typeof(TableNameAttribute), true).FirstOrDefault() as TableNameAttribute;
            return attribute.Name;
        }
    }
}
