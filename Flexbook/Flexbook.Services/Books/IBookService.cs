using Flexbook.Data.Models.Products;

namespace Flexbook.Services.Books;

public interface IBookService : ICrudService<Book>
{
    public List<Book> GetAllBooks();
}