using System.ComponentModel.DataAnnotations;
using Flexbook.Data.Models.Users;

namespace Flexbook.Data.Models.UserInteraction
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        [Required]
        public int LikesCount { get; set; }
        [Required]
        public User User { get; set; }
    }
}
