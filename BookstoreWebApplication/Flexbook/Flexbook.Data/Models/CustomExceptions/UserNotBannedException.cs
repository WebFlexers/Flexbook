namespace Flexbook.Data.Models.CustomExceptions
{
    public class UserNotBannedException : Exception
    {
        public UserNotBannedException() { }

        public UserNotBannedException(string message)
            : base(message) { }

        public UserNotBannedException(string message, Exception inner)
            : base(message, inner) { }
    }
}
