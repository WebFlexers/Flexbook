using Flexbook.Data.Models.UserManagement;

namespace Flexbook.Data.Models.Users
{
    public class Admin : UserBase, IAdmin
    {
        public override void Login()
        {
            throw new NotImplementedException();
        }

        public override void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
