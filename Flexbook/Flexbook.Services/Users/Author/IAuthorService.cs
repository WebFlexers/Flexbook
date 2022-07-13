using System;
using Flexbook.Data.Models.Users;
using Flexbook.Data.Models.Users.Components;

namespace Flexbook.Services
{
    public interface IAuthorService : ICrudService<Author>
    {
        public List<Author> GetAllAuthors();
        public Author? GetAuthorByEmail(string email);
        public Author? GetAuthorByName(string name);
    }
}
