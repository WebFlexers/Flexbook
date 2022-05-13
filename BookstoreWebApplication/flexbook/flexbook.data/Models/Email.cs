using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexbook.Data.Models
{
    public class Email
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
    }
}
