using System;

namespace Ca.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public int Code { get; private set; }
        public DomainException(int code, string message)
            : this(message)
        {
            Code = code;
        }

        public DomainException(string message)
            : base(message)
        {

        }
    }
}
