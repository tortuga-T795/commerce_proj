using System;

namespace ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableNameAttribute : Attribute, IDatabaseAttribute
    {
        public string Name { get; set; }

        public TableNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
