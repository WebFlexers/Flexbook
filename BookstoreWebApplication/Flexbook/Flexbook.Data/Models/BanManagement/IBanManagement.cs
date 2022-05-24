using Flexbook.Data.Models.UserManagement;

namespace Flexbook.Data.Models
{
    public interface IBanManagement
    {
        void BanUser(IUser user);
        void PardonUser(IUser user);
    }
}
