using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexbookData.Models
{
    public class Book : Product
    {
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
    }
}
