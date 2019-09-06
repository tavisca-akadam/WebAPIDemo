using System;
using System.Runtime.Serialization;

namespace WebAPIDemo.Service
{
    [Serializable]
    public class InvalidBookPriceException : Exception
    {
        public InvalidBookPriceException()
        {
        }

        public InvalidBookPriceException(string message) : base(message)
        {
        }

        public InvalidBookPriceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBookPriceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}