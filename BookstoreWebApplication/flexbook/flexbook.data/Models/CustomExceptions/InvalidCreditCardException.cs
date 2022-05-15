namespace Flexbook.Data.Models.CustomExceptions
{
    public class InvalidCreditCardException : Exception
    {
        public InvalidCreditCardException() { }

        public InvalidCreditCardException(string message)
            : base(message) { }

        public InvalidCreditCardException(string message, Exception inner)
            : base(message, inner) { }
    }
}
