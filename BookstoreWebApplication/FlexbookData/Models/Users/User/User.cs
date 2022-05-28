using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexbook.Data.Models
{
    public abstract class User
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public DateOnly Birthdate { get; set; }
        public string City { get; set; }
        public int Postcode { get; set; }
        public string Local_Phone_Num { get; set; }
        public string Mobile_Phone_Num { get; set; }
        public string Email { get; set; }

    }
}
