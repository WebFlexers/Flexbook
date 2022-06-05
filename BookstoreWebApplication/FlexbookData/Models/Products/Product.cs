using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FlexbookData.Models
{
    public abstract class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        [MaxLength(100)]
        public string Image { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [MaxLength(50)]
        public string Category { get; set; }
    }
}
