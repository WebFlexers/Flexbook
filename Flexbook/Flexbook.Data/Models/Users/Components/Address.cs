using System.ComponentModel.DataAnnotations;

namespace Flexbook.Data.Models.Users.Components
{
    public class Address
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        public int Number { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(5)]
        public string PostCode { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
