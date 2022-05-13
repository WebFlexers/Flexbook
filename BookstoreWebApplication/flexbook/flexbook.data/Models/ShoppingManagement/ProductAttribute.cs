using System.ComponentModel.DataAnnotations;

namespace Flexbook.Data.Models.ShoppingManagement
{
    public class ProductAttribute
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Attribute { get; set; }
        [Required]
        public string Value { get; set; }

    }
}
