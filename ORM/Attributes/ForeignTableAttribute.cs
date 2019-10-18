using ORM.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ForeignTableAttribute : Attribute
    {
        public List<DatabaseObject> ForeignTable { get; set; }

        public ForeignTableAttribute(List<DatabaseObject> table = null)
        {
            if(table == null)
            {
                ForeignTable = new List<DatabaseObject>();
            }


        }
    }
}
