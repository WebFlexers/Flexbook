using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexbookData.Models
{
    public abstract class User
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [Range(8, 16)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(254)]
        private string Email { get; set; }

        /*private DateOnly Birthdate { get; set; }
        private string City { get; set; }
        private int Postcode { get; set; }
        private string Local_Phone_Num { get; set; }
        private string Mobile_Phone_Num { get; set; }*/
    }
}
