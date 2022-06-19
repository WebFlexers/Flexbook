using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexbookData.Models
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
        [Column("image_path")]
        [MaxLength(100)]
        public string ImagePath { get; set; }
        [Required]
        [Column("date_written")]
        public DateTime DateWritten { get; set; }
        [Required]
        [Column("likes")]
        public int Likes { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }
        [ForeignKey("conversation_id")]
        public Conversation Conversation { get; set; }
    }
}
