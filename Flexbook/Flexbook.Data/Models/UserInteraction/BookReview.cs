using System.ComponentModel.DataAnnotations;
using Flexbook.Data.Models.Products;

namespace Flexbook.Data.Models.UserInteraction;


public class BookReview
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int Rating { get; set; }
    [Required]
    [MaxLength(255)]
    public string Comment { get; set; }
    [Required]
    public Book Book { get; set; }
}