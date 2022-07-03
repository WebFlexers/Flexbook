namespace Flexbook.Services.Users.User;

public interface IUserService : ICrudService<Data.Models.Users.User>
{
    public Data.Models.Users.User? GetByEmail(string email);
}