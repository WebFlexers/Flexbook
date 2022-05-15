namespace Flexbook.Data.Models.UserManagement
{
    /// <summary>
    /// Provides login and logout methods
    /// </summary>
    public interface ILoginManagement
    {
        string Username { get; }

        void Login();

        void Logout();
    }
}
