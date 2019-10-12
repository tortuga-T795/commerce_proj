using System;

namespace ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldNameAttribute : Attribute, IDatabaseAttribute
    {
        public string Name { get; set; }

        public FieldNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
