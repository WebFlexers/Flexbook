using Flexbook.Data.Models.Products;

namespace Flexbook.Services.Books;

public interface IBookService : ICrudService<Book>
{
    public List<Book> GetAll();
    public Book? GetByTitle(string title);
    public List<Book> GetByGenre(string genre);
    public List<Book> GetAllByAuthor(int authorId);
}