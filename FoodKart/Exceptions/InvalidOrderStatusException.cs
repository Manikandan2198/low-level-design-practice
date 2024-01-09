using System;
using System.Runtime.Serialization;

namespace FoodKart.Exceptions
{
    [Serializable]
    public class InvalidOrderStatusException : Exception
    {
        public InvalidOrderStatusException()
        {
        }

        public InvalidOrderStatusException(string message) : base(message)
        {
        }

        public InvalidOrderStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidOrderStatusException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}