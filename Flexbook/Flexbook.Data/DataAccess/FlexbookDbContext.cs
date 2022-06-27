using Flexbook.Data.Models.OrderSystem;
using Flexbook.Data.Models.Products;
using Flexbook.Data.Models.UserInteraction;
using Flexbook.Data.Models.Users;
using Flexbook.Data.Models.Users.Components;
using Microsoft.EntityFrameworkCore;

namespace Flexbook.Data.DataAccess;

public class FlexbookDbContext : DbContext
{
    public FlexbookDbContext() { }
    public FlexbookDbContext(DbContextOptions options): base(options) { }
    
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Comment> Comment { get; set; }
}