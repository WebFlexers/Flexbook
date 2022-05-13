using Flexbook.Data.Models.UserManagement;

namespace Flexbook.Data.Models.Users
{
    public interface IAdmin : IUser
    {
        IBanManagement BanManagement { get; }
    }
}
