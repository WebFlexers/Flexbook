using Flexbook.Data.Models;

namespace Flexbook.Services.AuthorForum;

public interface ICommentService
{
    public IEnumerable<Comment> GetAllCommentsByAuthor(int author_id);
}
