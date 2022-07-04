using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Products;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Flexbook.Services.Books;
public class BookService : CrudService<Book>, IBookService
{
    public BookService(FlexbookDbContext dbContext) : base(dbContext) { }

    public List<Book> GetAllBooks()
    {
        return _dbContext.Set<Book>().ToList();
    }

    [return: MaybeNull]
    public override Book GetById(int id)
    {
        return _dbContext.Set<Book>()
            .Include(book => book.Author)
            .FirstOrDefault(book => book.Id == id);
    }
}
