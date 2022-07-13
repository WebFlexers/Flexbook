using Flexbook.Data.Models;

namespace Flexbook.Services.AuthorForum;

public interface ICommentService : ICrudService<Comment>
{
    public IEnumerable<Comment> GetAllCommentsByAuthor(int authorId);

    public void AddLikeToComment(int commentId);
}
