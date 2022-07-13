using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Users;
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
    
    public List<Author> GetAllAuthors()
    {
        return _dbContext.Set<Author>()
            .Include(author => author.Address)
            .ToList();
    }

    public Author? GetAuthorByEmail(string email)
    {
        return _dbContext.Set<Author>()
            .Include(author => author.Address)
            .FirstOrDefault(author => author.Email == email);
    }

    public Author? GetAuthorByName(string name)
    {
        var formattedString = name.Replace("-", " ");
        return _dbContext.Set<Author>()
            .Include(author => author.Address)
            .FirstOrDefault(author => author.Fullname.ToLower() == formattedString.ToLower());
    }
}