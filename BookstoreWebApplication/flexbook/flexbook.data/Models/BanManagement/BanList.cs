using Flexbook.Data.Models.UserManagement;

namespace Flexbook.Data.Models.BanManagement
{
    /// <summary>
    /// Singleton class that represents the 
    /// currently banned or pardoned users
    /// </summary>
    public class BanList
    {
        private static BanList _instance;
        private BanList() 
        {
            BannedUsers = new List<IUser>();
            PardonedUsers = new List<IUser>();
        }

        public List<IUser> BannedUsers { get; set; }
        public List<IUser> PardonedUsers { get; set; }

        /// <summary>
        /// Gets the singleton instance
        /// </summary>
        /// <returns></returns>
        public static BanList GetInstance()
        {
            if (_instance == null)
                _instance = new BanList();

            return _instance;
        }
    }
}
