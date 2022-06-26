using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlexbookData.Models;

namespace FlexbookData.Models
{
    [Table("authors")]
    public class Author : User, ILogin
    {
        [Required]
        [Column("description")]
        [MaxLength(510)]
        public string Description { get; set; }

        [NotMapped]
        public List<Book> Books_List { get; set; }

        public void Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
