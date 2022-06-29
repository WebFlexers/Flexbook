using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flexbook.Data.Models.LoginSystem;
using Flexbook.Data.Models.Products;

namespace Flexbook.Data.Models.Users
{
    public class Author : User
    {
        [Required]
        [MaxLength(510)]
        public string Description { get; set; }
    }
}
