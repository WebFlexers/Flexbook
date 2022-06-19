using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexbookData.Models
{
    public class Conversation
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("host_id")]
        public User Host { get; set; }
        [ForeignKey("initial_comment_id")]
        public Comment InitialComment { get; set; }
        [NotMapped]
        public List<Comment> Comments { get; set; }
    }
}
