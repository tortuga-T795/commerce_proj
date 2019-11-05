using System;

namespace ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ReadOnlyFieldAttribute : Attribute
    { }
}
