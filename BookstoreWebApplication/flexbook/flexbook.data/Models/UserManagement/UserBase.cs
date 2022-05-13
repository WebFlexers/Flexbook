using System.ComponentModel.DataAnnotations;

namespace Flexbook.Data.Models.UserManagement
{
    public abstract class UserBase : IUser
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; private set; }
        [Required]
        [MaxLength(25)]
        public char[] Password { get; private set; }

        public abstract void Login();
        public abstract void Logout();       
    }
}
