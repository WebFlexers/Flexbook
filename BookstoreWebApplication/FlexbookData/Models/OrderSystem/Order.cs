using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexbookData.Models
{
    public class Order
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("ordered_time")]
        public DateTime Ordered_Time { get; set; }
        [Required]
        [Column("payment_method")]
        [MaxLength(50)]
        public string Payment_Method { get; set; }
        [Required]
        [Column("status")]
        [MaxLength(50)]
        public string Status { get; set; }
        [Required]
        [Column("discount")]
        public float Discount { get; set; }
        [Required]
        [Column("total_price")]
        public int Total_Price { get; set; }
        [ForeignKey("customer_id")]
        public Customer Customer { get; set; }
    }
}
