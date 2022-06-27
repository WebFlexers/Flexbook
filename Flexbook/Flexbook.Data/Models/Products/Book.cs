using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flexbook.Data.Models.Users;

namespace Flexbook.Data.Models.Products
{
    [Table("books")]
    public class Book : Product
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("isbn")]
        [StringLength(13)]
        public string ISBN { get; set; }
        [Required]
        [Column("genre")]
        [MaxLength(50)]
        public string Genre { get; set; }
        [Required]
        [Column("publisher")]
        [MaxLength(50)]
        public string Publisher { get; set; }
        [Required]
        [Column("publication_date")]
        public DateOnly PublicationDate { get; set; }
        [Required]
        [Column("pages")]
        public int Pages { get; set; }
        [Required]
        [Column("language")]
        [MaxLength(50)]
        public DateOnly Language { get; set; }
        [Required]
        [Column("summary")]
        [MaxLength(255)]
        public string Summary { get; set; }
        [Required]
        [ForeignKey("author_id")]
        public Author Author { get; set; }
        [ForeignKey("product_id")]
        public Product Product { get; set; }
    }
}
