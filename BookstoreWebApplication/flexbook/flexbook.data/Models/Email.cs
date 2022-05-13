using System.ComponentModel.DataAnnotations;

namespace Flexbook.Data.Models
{
    public class Email
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
    }
}
