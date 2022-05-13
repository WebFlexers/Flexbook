namespace Flexbook.Data.Models.UserManagement
{
    /// <summary>
    /// Provides login and logout methods
    /// </summary>
    public interface ILoginManagement
    {
        string Username { get; }

        /// <summary>
        /// Logs the user in the system
        /// </summary>
        void Login();

        /// <summary>
        /// Logs the user out of the system
        /// </summary>
        void Logout();
    }
}
