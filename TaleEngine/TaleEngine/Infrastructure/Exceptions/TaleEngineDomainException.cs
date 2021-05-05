using System;

namespace TaleEngine.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class TaleEngineDomainException : Exception
    {
        public TaleEngineDomainException()
        { }

        public TaleEngineDomainException(string message)
            : base(message)
        { }

        public TaleEngineDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
