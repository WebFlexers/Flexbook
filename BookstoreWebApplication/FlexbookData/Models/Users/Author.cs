using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlexbookData.Models;

namespace FlexbookData.Models
{
    public class Author : User, ILogin
    {
        [NotMapped]
        public List<Book> Books_List { get; set; }

        public void Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
