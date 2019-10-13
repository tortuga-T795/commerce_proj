using System;
using System.Reflection;

namespace ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKeyAttribute : Attribute
    {
        public Type ReferencesType { get; private set; }
        public PropertyInfo ReferencesProperty { get; private set; }

        public ForeignKeyAttribute(Type refType, string propName)
        {
            ReferencesType = refType;
            ReferencesProperty = ReferencesType.GetProperty(propName);
        }
    }
}
