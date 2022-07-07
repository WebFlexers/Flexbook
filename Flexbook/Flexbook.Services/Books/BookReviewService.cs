using Flexbook.Data.DataAccess;
using Flexbook.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Flexbook.Services.Books;

public class BookReviewService : CrudService<BookReview>, IBookReviewService
{
    public BookReviewService(FlexbookDbContext dbContext) : base(dbContext) { }

    public override BookReview? GetById(int id)
    {
        return _dbContext.Set<BookReview>()
            .Include(review => review.Book)
            .Include(review => review.User)
            .FirstOrDefault(review => review.Id == id);
    }

    public IEnumerable<BookReview> GetAllReviewsByBook(int book_id)
    {
        return _dbContext.Set<BookReview>().Where(review => review.Book.Id == book_id)
            .Include(review => review.Book).Include(review => review.User).ToList();
    }
}
