using Flexbook.Data.Models.Users;

namespace Flexbook.Services.Session;

public interface ILoginService
{
    public User? GetUserWithCredentials(string username, string password);
    public string GetUserType(User user);
}