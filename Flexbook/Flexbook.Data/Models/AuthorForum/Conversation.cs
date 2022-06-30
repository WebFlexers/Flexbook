using Flexbook.Data.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Flexbook.Data.Models
{
    public class Conversation
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Author Author_id { get; set; }
        // First comment of list is the initial comment
        // Initialize the property by sorting by CreatedOn date
        [Required]
        public List<Comment> Comments { get; set; }
    }
}
