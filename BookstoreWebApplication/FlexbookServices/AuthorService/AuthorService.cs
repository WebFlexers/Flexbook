using System;
using FlexbookData.Models;
using FlexbookData.DataAccess;
using FlexbookServices;

namespace FlexbookServices
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        public AuthorService(FlexbookContext dbContext) : base(dbContext) { }   
    }
}
