using System;

namespace ORM.Exceptions
{
    public class IncorrectTypeException : Exception
    {
        public IncorrectTypeException(Type type) : base(string.Format("This ORM can't work with {0} type.", type.Name))
        { }

        public IncorrectTypeException(string msg) : base(msg)
        { }
    }
}
