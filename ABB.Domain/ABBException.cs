using System;

namespace ABB.Domain
{
    public class UnprocessableException : Exception
    {
        public UnprocessableException(string message) : base(message) { }
    }
    public class AccessForbiddenException : Exception
    {
        public AccessForbiddenException(string message) : base(message) { }
    }
}
