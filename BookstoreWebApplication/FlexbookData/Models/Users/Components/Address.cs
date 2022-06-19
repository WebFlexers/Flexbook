using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexbookData.Models
{
    [Table("address")]
    public class Address
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column("number")]
        public int Number { get; set; }
        [Required]
        [Column("city")]
        public string City { get; set; }
        [Required]
        [Column("postcode")]
        [StringLength(5)]
        public string PostCode { get; set; } 
    }
}
