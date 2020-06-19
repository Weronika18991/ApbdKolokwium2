using System;

namespace ApbdKolokwium2.Exceptions
{
    public class IncorrectTimeException : Exception
    {
        public IncorrectTimeException()
        {
        }

        public IncorrectTimeException(string message) : base(message)
        {
        }

        public IncorrectTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}