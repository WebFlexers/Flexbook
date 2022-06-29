using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Users;

namespace Flexbook.Services.Session;

public class LoginService : ILoginService
{
    private readonly FlexbookDbContext _dbContext;

    public LoginService(FlexbookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public User? GetUserWithCredentials(string username, string password)
    {
        return _dbContext.Users.FirstOrDefault(o =>
            o != null && o.Username.ToLower() == username.ToLower() 
                      && o.Password == password) ?? null;
    }

    public string GetUserType(User user)
    {
        return user switch
        {
            Customer => "Customer",
            Author => "Author",
            _ => null
        } ?? string.Empty;
    }
}