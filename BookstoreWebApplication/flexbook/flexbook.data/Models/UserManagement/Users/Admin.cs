using Flexbook.Data.Models.UserManagement;

namespace Flexbook.Data.Models.Users
{
    public class Admin : UserBase, IAdmin
    {
        public IBanManagement BanManagement { get; set; }
        public string LandLineNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public Email Email { get; set; }

        public Admin(IBanManagement banManagement)
        {
            BanManagement = banManagement;
        }

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
