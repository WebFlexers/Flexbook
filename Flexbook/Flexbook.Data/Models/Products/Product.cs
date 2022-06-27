using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flexbook.Data.Models.Products
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
        [Required]
        [Column("image")]
        [MaxLength(100)]
        public string Image { get; set; }
        [Required]
        [Column("starting_price")]
        public int StartingPrice { get; set; }
        [Required]
        [Column("final_price")]
        public int FinalPrice { get; set; }
    }
}
