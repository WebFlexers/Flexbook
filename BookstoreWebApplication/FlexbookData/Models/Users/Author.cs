using FlexbookData.Models;

namespace FlexbookData.Models
{
    public class Author : User, ILogin
    {
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
