using System.ComponentModel.DataAnnotations;

namespace Flexbook.Data.Models.Users
{
    public class Customer : User
    {
        [MaxLength(10)]
        public string FaxNumber { get; set; }
    }
}
