namespace Flexbook.Data.Models.CustomExceptions
{
    public class UserAlreadyPardonedException : Exception
    {
        public UserAlreadyPardonedException() { }

        public UserAlreadyPardonedException(string message)
            : base(message) { }

        public UserAlreadyPardonedException(string message, Exception inner)
            : base(message, inner) { }
    }
}
