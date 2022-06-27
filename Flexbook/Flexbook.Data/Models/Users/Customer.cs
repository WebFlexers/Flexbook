using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flexbook.Data.Models.Users
{
    [Table("customers")]
    public class Customer : User
    {
        [Column("fax_number")]
        [MaxLength(10)]
        public string FaxNumber { get; set; }
    }
}
