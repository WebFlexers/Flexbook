using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flexbook.Data.Models.Users;

namespace Flexbook.Data.Models.OrderSystem
{
    public class Order
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("ordered_time")]
        public DateTime OrderedTime { get; set; }
        [Required]
        [Column("payment_method")]
        [MaxLength(50)]
        public string PaymentMethod { get; set; }
        [Required]
        [Column("status")]
        [MaxLength(50)]
        public string Status { get; set; }
        [Required]
        [Column("discount")]
        public float Discount { get; set; }
        [Required]
        [Column("total_price")]
        public int TotalPrice { get; set; }
        [ForeignKey("customer_id")]
        public Customer Customer { get; set; }
    }
}
