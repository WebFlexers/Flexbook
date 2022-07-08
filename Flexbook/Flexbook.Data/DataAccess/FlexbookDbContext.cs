using Flexbook.Data.Models.OrderSystem;
using Flexbook.Data.Models.Products;
using Flexbook.Data.Models.Users;
using Flexbook.Data.Models.Users.Components;
using Microsoft.EntityFrameworkCore;
using Flexbook.Data.Models;

namespace Flexbook.Data.DataAccess;

public class FlexbookDbContext : DbContext
{
    public FlexbookDbContext() { }
    public FlexbookDbContext(DbContextOptions options): base(options) { }
    
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Comment> Comments { get; set; }
    
    public DbSet<User?> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<BookReview> BookReviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Use Table Per Type approach
        // Users
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Author>().ToTable("Authors");
        
        // Products
        modelBuilder.Entity<Book>().ToTable("Books");

        // Unique Constraints
        // User
        modelBuilder.Entity<User>()
           .HasAlternateKey(user => user.Username);
        modelBuilder.Entity<User>()
           .HasAlternateKey(user => user.Email);
        modelBuilder.Entity<User>()
           .HasAlternateKey(user => user.PhoneNumber);
        // Book
        modelBuilder.Entity<Book>()
            .HasIndex(book => book.ISBN)
            .IsUnique();
    }
    
}