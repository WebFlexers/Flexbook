using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexbookData.Models
{
    public abstract class Product
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("image")]
        [MaxLength(100)]
        public string Image { get; set; }
        [Required]
        [Column("price")]
        public int Price { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("category")]
        public string Category { get; set; }
    }
}
