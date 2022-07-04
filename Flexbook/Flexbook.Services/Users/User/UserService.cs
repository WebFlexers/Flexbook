using Flexbook.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Flexbook.Services.Users.User;

public class UserService : CrudService<Data.Models.Users.User>, IUserService
{
    public UserService(FlexbookDbContext dbContext) : base(dbContext) {}
    
    public Data.Models.Users.User? GetByEmail(string email)
    {
        return _dbContext.Set<Data.Models.Users.User>()
            .Include(user => user.Address)
            .FirstOrDefault(user => user.Email == email);
    }

    public override Data.Models.Users.User? GetById(int id)
    {
        return _dbContext.Set<Data.Models.Users.User>()
            .Include(user => user.Address)
            .FirstOrDefault(user => user.Id == id);
    }
}