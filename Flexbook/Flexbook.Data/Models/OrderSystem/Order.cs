using System.ComponentModel.DataAnnotations;
using Flexbook.Data.Models.Users;

namespace Flexbook.Data.Models.OrderSystem
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; }
        [Required]
        public List<OrderItem> Items { get; set; }
        [Required]
        [MaxLength(50)]
        public string Status { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public Customer Customer { get; set; }
    }
}
