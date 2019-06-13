using System;
using System.Runtime.Serialization;

namespace XmlService
{
    public class XsdValidationException : Exception
    {
        public XsdValidationException()
        {
        }

        public XsdValidationException(string message) : base(message)
        {
        }

        public XsdValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected XsdValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
