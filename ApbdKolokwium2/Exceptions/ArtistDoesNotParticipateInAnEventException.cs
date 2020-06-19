using System;

namespace ApbdKolokwium2.Exceptions
{
    public class ArtistDoesNotParticipateInAnEventException : Exception
    {
        public ArtistDoesNotParticipateInAnEventException()
        {
        }

        public ArtistDoesNotParticipateInAnEventException(string message) : base(message)
        {
        }

        public ArtistDoesNotParticipateInAnEventException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}