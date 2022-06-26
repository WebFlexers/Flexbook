using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexbookData.Models
{
    public abstract class User
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("username")]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        [Range(8, 16)]
        public string Password { get; set; }
        [Required]
        [Column("fullname")]
        [MaxLength(50)]
        public string Fullname { get; set; }
        [Required]
        [Column("email")]
        [MaxLength(254)]
        public string Email { get; set; }
        [ForeignKey("address_id")]
        public Address Address { get; set; }
        [Required]
        [Column("age")]
        public int Age { get; set; }
        [Required]
        [Column("phone_num")]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        [Column("image_path")]
        [MaxLength(100)]
        public string ImagePath { get; set; }
    }
}
