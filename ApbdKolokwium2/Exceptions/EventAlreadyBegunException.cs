using System;

namespace ApbdKolokwium2.Exceptions
{
    public class EventAlreadyBegunException : Exception
    {
        public EventAlreadyBegunException()
        {
        }

        public EventAlreadyBegunException(string message) : base(message)
        {
        }

        public EventAlreadyBegunException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}