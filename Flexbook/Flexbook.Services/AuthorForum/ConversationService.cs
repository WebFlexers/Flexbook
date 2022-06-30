using Flexbook.Data.DataAccess;
using Flexbook.Data.Models;

namespace Flexbook.Services.AuthorForum
{
    public class ConversationService : CrudService<Conversation>, IConversationService
    {
        public ConversationService(FlexbookDbContext dbContext) : base(dbContext) { }
    }
}
