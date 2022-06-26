using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexbookData.Models
{
    [Table("customers")]
    public class Customer : User
    {
        [Column("fax_num")]
        [MaxLength(10)]
        public string FaxNumber { get; set; }
    }
}
