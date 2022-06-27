using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flexbook.Data.Models.Products;

namespace Flexbook.Data.Models.OrderSystem
{
    public class OrderItem
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }
        [ForeignKey("product_id")]
        public Product Product { get; set; }
        [ForeignKey("order_id")]
        public Order Order { get; set; }
    }
}
