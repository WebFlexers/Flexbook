using System.ComponentModel.DataAnnotations;
using Flexbook.Data.Models.Products;

namespace Flexbook.Data.Models.OrderSystem
{
    public class OrderItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
