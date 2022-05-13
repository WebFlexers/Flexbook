namespace Flexbook.Data.Models.CustomExceptions
{
    public class UserAlreadyBannedException : Exception
    {
        public UserAlreadyBannedException() { }

        public UserAlreadyBannedException(string message)
            : base(message) { }

        public UserAlreadyBannedException(string message, Exception inner)
            : base(message, inner) { }
    }
}
