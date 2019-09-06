using System;
using System.Runtime.Serialization;

namespace WebAPIDemo.Service
{
    [Serializable]
    public class InvalidBookException : Exception
    {
        public InvalidBookException()
        {
        }

        public InvalidBookException(string message) : base(message)
        {
        }

        public InvalidBookException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBookException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}