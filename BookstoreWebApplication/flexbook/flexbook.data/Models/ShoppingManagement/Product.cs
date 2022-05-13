using System.ComponentModel.DataAnnotations;

namespace Flexbook.Data.Models.ShoppingManagement
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public decimal StartingPrice { get; set; }
        [Required]
        public decimal FinalPrice { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        public List<ProductAttribute> Attributes { get; set; }

    }
}
