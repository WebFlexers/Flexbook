using Flexbook.Data.Models.UserManagement;

namespace Flexbook.Data.Models.Users
{
    public interface IAdmin : IUser
    {
        IBanManagement BanManagement { get; }
        string LandLineNumber { get; set; }
        string MobilePhoneNumber { get; set; }
        Email Email { get; set; }
    }
}
