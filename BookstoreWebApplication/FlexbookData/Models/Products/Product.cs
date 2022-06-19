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
        [Required]
        [Column("image_path")]
        [MaxLength(100)]
        public string ImagePath { get; set; }
        [Required]
        [Column("starting_price")]
        public int Starting_Price { get; set; }
        [Required]
        [Column("final_price")]
        public int Final_Price { get; set; }
    }
}
