using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Users;
using Flexbook.Data.Models.Users.Components;
using Microsoft.EntityFrameworkCore;

namespace Flexbook.Services;

public class AuthorService : CrudService<Author>, IAuthorService
{
    public AuthorService(FlexbookDbContext dbContext) : base(dbContext) {}

    public override Author? GetById(int id)
    {
        return _dbContext.Set<Author>()
            .Include(author => author.Address)
            .FirstOrDefault(author => author.Id == id);
    }
}