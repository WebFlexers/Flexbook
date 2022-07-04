using Flexbook.Data.Models;

namespace Flexbook.Services.AuthorForum;

public interface ICommentService : ICrudService<Comment>
{
    public IEnumerable<Comment> GetAllCommentsByAuthor(int author_id);

    public void AddLikeToComment(int comment_id);
}
