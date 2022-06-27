using System.ComponentModel.DataAnnotations;

namespace Flexbook.Data.Models.ConversationSystem;


public class BookReview
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int Rating { get; set; }
    [MaxLength(255)]
    public string Comment { get; set; }
}