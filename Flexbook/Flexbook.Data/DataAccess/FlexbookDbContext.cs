using Flexbook.Data.Models.ConversationSystem;
using Flexbook.Data.Models.OrderSystem;
using Flexbook.Data.Models.Products;
using Flexbook.Data.Models.Users;
using Flexbook.Data.Models.Users.Components;
using Microsoft.EntityFrameworkCore;

namespace Flexbook.Data.DataAccess;

public class FlexbookDbContext : DbContext
{
    public FlexbookDbContext() { }
    public FlexbookDbContext(DbContextOptions options): base(options) { }
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderItem> OrderItems { get; set; }
    public virtual DbSet<Conversation> Conversations { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
}