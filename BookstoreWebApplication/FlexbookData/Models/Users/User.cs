using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexbookData.Models
{
    public abstract class User
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }

        /*private DateOnly Birthdate { get; set; }
        private string City { get; set; }
        private int Postcode { get; set; }
        private string Local_Phone_Num { get; set; }
        private string Mobile_Phone_Num { get; set; }
        private string Email { get; set; }*/
    }
}
