using System;

namespace TaleEngine.Data.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
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