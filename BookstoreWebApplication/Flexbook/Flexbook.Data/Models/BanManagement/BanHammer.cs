using Flexbook.Data.Models.CustomExceptions;
using Flexbook.Data.Models.UserManagement;

namespace Flexbook.Data.Models.BanManagement
{
    /// <summary>
    /// Used to ban and unban users
    /// </summary>
    public class BanHammer : IBanManagement
    {
        /// <summary>
        /// Adds a user to the ban list
        /// </summary>
        /// <param name="user"> The user to add </param>
        /// <exception cref="UserAlreadyBannedException"></exception>
        public void BanUser(IUser user)
        {
            var banList = BanList.GetInstance().BannedUsers;

            // Check if user is already banned
            if (banList.Contains(user))
            {
                throw new UserAlreadyBannedException("The given user is already in the ban list");
            }

            // Check if a user was previously banned
            var pardonList = BanList.GetInstance().PardonedUsers;
            if (pardonList.Contains(user))
            {
                // Remove user from the pardon list since they will be banned again
                pardonList.Remove(user);
            }

            banList.Add(user);
        }
  
        /// <summary>
        /// Pardons a banned user by removing them from the banned list
        /// and adding them to the pardoned list
        /// </summary>
        /// <param name="user"> The user to pardon </param>
        /// <exception cref="UserNotBannedException"></exception>
        /// <exception cref="UserAlreadyPardonedException"></exception>
        public void PardonUser(IUser user)
        {
            var banList = BanList.GetInstance().BannedUsers;
            if (banList.Contains(user) == false)
            {
                throw new UserNotBannedException("The given user is not banned, so they can't be pardoned");
            }

            var pardonedList = BanList.GetInstance().PardonedUsers;
            if (pardonedList.Contains(user))
            {
                throw new UserAlreadyPardonedException("The given user is already in the pardon list");
            }

            banList.Remove(user);
            pardonedList.Add(user);
        }
    }
}
