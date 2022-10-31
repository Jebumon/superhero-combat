using System.Runtime.Serialization;

namespace SuperheroAPI.Repository
{
    [Serializable]
    internal class InvalidSuperHeroNameException : Exception
    {
        public InvalidSuperHeroNameException()
        {
        }

        public InvalidSuperHeroNameException(string? message) : base(message)
        {
        }

        public InvalidSuperHeroNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidSuperHeroNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}