using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexbookData.Models;

namespace FlexbookData.DataAccess
{
    public class FlexbookContext : DbContext
    {
        public FlexbookContext(DbContextOptions options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> order_items { get; set; }
        public DbSet<Conversation> conversations { get; set; }
        public DbSet<Comment> comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("authors");
            modelBuilder.Entity<Customer>().ToTable("customer");
        }
    }
}


