using System.ComponentModel.DataAnnotations;

namespace Flexbook.Data.Models.ShoppingManagement
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}
