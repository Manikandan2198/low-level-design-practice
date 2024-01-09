using System;
using System.Runtime.Serialization;

namespace CachingSystem.Exceptions
{
    [Serializable]
    public class StorageFullException : Exception
    {
        public StorageFullException()
        {
        }

        public StorageFullException(string message) : base(message)
        {
        }

        public StorageFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StorageFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}