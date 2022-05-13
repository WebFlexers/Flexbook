using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexbook.Data.Models
{
    /// <summary>
    /// Contains all the necessary info for an address
    /// </summary>
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string StreetAddress { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string State { get; set; }
        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }
    }
}
