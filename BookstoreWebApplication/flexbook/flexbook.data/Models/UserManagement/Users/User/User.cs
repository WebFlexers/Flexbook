using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexbook.Data.Models
{
    abstract class User
    {
        public abstract string ID { get; set; }
        public abstract string Username { get; set; }
        public abstract string Password { get; set; }
        public abstract string Fullname { get; set; }
        public abstract DateOnly Birthdate { get; set; }
        public abstract string City { get; set; }
        public abstract int Postcode { get; set; }
        public abstract string Local_Phone_Num { get; set; }
        public abstract string Mobile_Phone_Num { get; set; }
        public abstract string Email { get; set; }

    }
}
