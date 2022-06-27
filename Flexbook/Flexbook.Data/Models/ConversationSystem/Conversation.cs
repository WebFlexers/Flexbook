using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flexbook.Data.Models.Users;

namespace Flexbook.Data.Models.ConversationSystem
{
    public class Conversation
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("host_user_id")]
        public User HostUser { get; set; }
        [ForeignKey("initial_comment_id")]
        public Comment InitialComment { get; set; }
        [NotMapped]
        public List<Comment> Answers { get; set; }
    }
}
