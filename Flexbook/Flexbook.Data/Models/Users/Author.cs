using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flexbook.Data.Models.LoginSystem;
using Flexbook.Data.Models.Products;

namespace Flexbook.Data.Models.Users
{
    public class Author : User, ILogin
    {
        [Required]
        [MaxLength(510)]
        public string Description { get; set; }

        [NotMapped]
        public List<Book> BooksList { get; set; }
        
        public void Login(string username, char[] password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
