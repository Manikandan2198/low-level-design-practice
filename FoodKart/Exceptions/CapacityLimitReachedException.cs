using System;
using System.Runtime.Serialization;

namespace FoodKart.Exceptions
{
    [Serializable]
    public class CapacityLimitReachedException : Exception
    {
        public CapacityLimitReachedException()
        {
        }

        public CapacityLimitReachedException(string message) : base(message)
        {
        }

        public CapacityLimitReachedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CapacityLimitReachedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}