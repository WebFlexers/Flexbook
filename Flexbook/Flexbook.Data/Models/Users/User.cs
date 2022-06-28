using System.ComponentModel.DataAnnotations;
using Flexbook.Data.Models.Users.Components;

namespace Flexbook.Data.Models.Users
{
    public abstract class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [Range(8, 16)]
        public char[] Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(254)]
        public string Email { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string Image { get; set; }
    }
}
