using Flexbook.Data.Models.Users;

namespace Flexbook.Services.SessionServices;

public interface ILoginService
{
    public User? GetUserWithCredentials(string username, string password);
    public string GetUserType(User user);
}