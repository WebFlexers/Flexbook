using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flexbook.Data.Models.Users;

namespace Flexbook.Data.Models.ConversationSystem
{
    public class Comment
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("content")]
        [MaxLength(255)]
        public string Content { get; set; }
        [Required]
        [Column("image")]
        [MaxLength(100)]
        public string Image { get; set; }
        [Required]
        [Column("datetime_written")]
        public DateTime DateWritten { get; set; }
        [Required]
        [Column("likes_count")]
        public int LikesCount { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }
        [ForeignKey("conversation_id")]
        public Conversation Conversation { get; set; }
    }
}
