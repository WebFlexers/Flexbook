using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Flexbook.Services.Books;
public class BookService : CrudService<Book>, IBookService
{
    public BookService(FlexbookDbContext dbContext) : base(dbContext) { }

    public List<Book> GetAll()
    {
        return _dbContext.Set<Book>()
            .Include(book => book.Author)
            .ToList();
    }

    public List<Book> GetByGenre(string genre)
    {
        return _dbContext.Set<Book>()
            .Where(book => book.Genre == genre)
            .Include(book => book.Author)
            .ToList();
    }

    public List<Book> GetAllByAuthor(int authorId)
    {
        return _dbContext.Set<Book>()
            .Where(book => book.Author.Id == authorId)
            .Include(book => book.Author)
            .ToList();
    }

    public Book? GetByTitle(string title)
    {
        var formattedString = title.Replace("-", " ");
        return _dbContext.Set<Book>()
            .Include(book => book.Author)
            .FirstOrDefault(book => book.Title.ToLower() == formattedString.ToLower());
    }
    
    public override Book? GetById(int id)
    {
        return _dbContext.Set<Book>()
            .Include(book => book.Author)
            .FirstOrDefault(book => book.Id == id);
    }
}