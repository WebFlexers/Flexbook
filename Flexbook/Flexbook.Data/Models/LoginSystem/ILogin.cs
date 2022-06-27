namespace Flexbook.Data.Models.LoginSystem
{
    public interface ILogin
    {
        void Login(string username, char[] password);

        void Logout();
    }
}
