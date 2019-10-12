using System;

namespace ORM.Exceptions
{
    public class RowIsNullException : Exception
    {
        public RowIsNullException()
        { }

        public RowIsNullException(string message) : base(message)
        { }
    }
}
