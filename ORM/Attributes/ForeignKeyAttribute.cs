using System;
using System.Reflection;

namespace ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKeyAttribute : Attribute
    {
        public Type ReferencesType { get; private set; }
        public PropertyInfo ReferencesProperty { get; private set; }
        public PropertyInfo PrintProperty { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="refType">Type to reference</param>
        /// <param name="propName">Name of the property to be referenced</param>
        /// <param name="printPropName">Name of the property to be printed when data is displayed</param>
        public ForeignKeyAttribute(Type refType, string propName, string printPropName)
        {
            ReferencesType = refType;
            ReferencesProperty = ReferencesType.GetProperty(propName);
            PrintProperty = ReferencesType.GetProperty(printPropName);
        }
    }
}
