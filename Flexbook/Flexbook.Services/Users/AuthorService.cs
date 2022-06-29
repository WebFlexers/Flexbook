using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Flexbook.Services.Users;

public class AuthorService : CrudService<Author>, ICrudService<Author>
{
    public AuthorService(FlexbookDbContext dbContext) : base(dbContext) {}
    
    public override Author GetById(int id)
    {
        return _dbContext.Set<Author>()
            .Include(author => author.Address)
            .FirstOrDefault();
    }
}