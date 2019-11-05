using System;

namespace ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ReadOnlyTableAttribute : Attribute
    { }
}
