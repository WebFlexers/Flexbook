using Flexbook.Data.DataAccess;
using Flexbook.Data.Models;

namespace Flexbook.Services.AuthorForum
{
    public class CommentService : CrudService<Comment>, ICommentService
    {
        public CommentService(FlexbookDbContext dbContext) : base(dbContext) { }

        public IEnumerable<Comment> GetAllCommentsByAuthor(int author_id)
        {
            return _dbContext.Comments.Where(comment => comment.AuthorHost.Id == author_id);          
        }
    }
}
