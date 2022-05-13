using Flexbook.Data.Models.UserManagement;

namespace Flexbook.Data.Models.Users
{
    public class Author : UserBase, IAuthor
    {
        public override void Login()
        {
            throw new NotImplementedException();
        }

        public override void Logout()
        {
            throw new NotImplementedException();
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}
