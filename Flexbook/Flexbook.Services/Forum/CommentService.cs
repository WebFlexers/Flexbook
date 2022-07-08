using Flexbook.Data.DataAccess;
using Flexbook.Data.Models;
using Flexbook.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Flexbook.Services.AuthorForum;

public class CommentService : CrudService<Comment>, ICommentService
{
    public CommentService(FlexbookDbContext dbContext) : base(dbContext) { }

    public override Comment? GetById(int id)
    {
        return _dbContext.Set<Comment>()
            .Include(comment => comment.User)
            .Include(comment => comment.AuthorHost)
            .FirstOrDefault(comment => comment.Id == id);
    }

    public IEnumerable<Comment> GetAllCommentsByAuthor(int author_id)
    {
        return _dbContext.Set<Comment>().Where(comment => comment.AuthorHost.Id == author_id)
            .Include(comment => comment.User).Include(comment => comment.AuthorHost).ToList();
    }

    public void AddLikeToComment(int comment_id)
    {
        var result = _dbContext.Set<Comment>().SingleOrDefault(c => c.Id == comment_id);
        if (result != null)
        {
            result.LikesCount++;
            _dbContext.SaveChanges();
        }
    }
}
