using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexbookData.Models
{
    public class Book : Product
    {
        [Required]
        [Column("isbn")]
        [StringLength(13)]
        public string ISBN { get; set; }
        [Required]
        [Column("genre")]
        [MaxLength(50)]
        public string Genre { get; set; }
        [Required]
        [Column("pages")]
        public int Pages { get; set; }
    }
}
