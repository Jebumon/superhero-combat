using System.Runtime.Serialization;

namespace SuperheroAPI.Repository.Exceptions
{
    [Serializable]
    internal class PowerStatNullException : Exception
    {
        public PowerStatNullException()
        {
        }

        public PowerStatNullException(string? message) : base(message)
        {
        }

        public PowerStatNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PowerStatNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}