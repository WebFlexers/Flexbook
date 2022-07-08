using Flexbook.Data.Models;

namespace Flexbook.Services.Books;

public interface IBookReviewService : ICrudService<BookReview>
{
    public IEnumerable<BookReview> GetAllReviewsByBook(int book_id);
}
