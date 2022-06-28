using System.ComponentModel.DataAnnotations;

namespace Flexbook.Data.Models.Products
{
    public abstract class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string Image { get; set; }
        [Required]
        public double StartingPrice { get; set; }
        [Required]
        public double FinalPrice { get; set; }
    }
}
