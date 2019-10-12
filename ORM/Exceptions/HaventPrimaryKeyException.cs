using System;

namespace ORM.Exceptions
{
    public class HaventPrimaryKeyException : Exception
    {
        public HaventPrimaryKeyException(Type type) : base(string.Format("Type {0} haven't primary key property", type.Name))
        { }

        public HaventPrimaryKeyException(string message) : base(message)
        { }
    }
}
