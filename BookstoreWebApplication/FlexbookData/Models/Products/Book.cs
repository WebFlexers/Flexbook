using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FlexbookData.Models
{
    public class Book : Product
    {
        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }
        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }
        [Required]
        public int Pages { get; set; }
    }
}
