using System;

namespace ApbdKolokwium2.Exceptions
{
    public class EventDoesNotExistsException : Exception
    {
        public EventDoesNotExistsException()
        {
        }

        public EventDoesNotExistsException(string message) : base(message)
        {
        }

        public EventDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}