using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Products;

namespace Flexbook.Services.Books;

public class BookService : CrudService<Book>, IBookService
{
    public BookService(FlexbookDbContext dbContext) : base(dbContext) { }

    public List<Book> GetAllBooks()
    {
        return _dbContext.Book.ToList();
    }
}