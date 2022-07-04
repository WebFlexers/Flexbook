using System.ComponentModel.DataAnnotations;
using Flexbook.Data.Models.Products;
using Flexbook.Data.Models.Users;

namespace Flexbook.Data.Models;


public class BookReview
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int Rating { get; set; }
    [Required]
    [MaxLength(255)]
    public string Content { get; set; }
    [Required]
    public Book Book { get; set; }
    [Required]
    public User User { get; set; }
}