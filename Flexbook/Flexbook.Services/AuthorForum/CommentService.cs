using Flexbook.Data.DataAccess;
using Flexbook.Data.Models;

namespace Flexbook.Services.AuthorForum
{
    public class CommentService : CrudService<Comment>, ICommentService
    {
        public CommentService(FlexbookDbContext dbContext) : base(dbContext) { }
    }
}
