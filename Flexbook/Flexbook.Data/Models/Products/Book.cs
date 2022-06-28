using System.ComponentModel.DataAnnotations;
using Flexbook.Data.Models.Users;

namespace Flexbook.Data.Models.Products
{
    public class Book : Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }
        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Publisher { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required]
        [MaxLength(50)]
        public string Language { get; set; }
        [Required]
        [MaxLength(255)]
        public string Summary { get; set; }
        [Required]
        public Author Author { get; set; }
    }
}