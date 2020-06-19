using System;

namespace ApbdKolokwium2.Exceptions
{
    public class ArtistDoesNotExistsException : Exception
    {
        public ArtistDoesNotExistsException()
        {
        }

        public ArtistDoesNotExistsException(string message) : base(message)
        {
        }

        public ArtistDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}