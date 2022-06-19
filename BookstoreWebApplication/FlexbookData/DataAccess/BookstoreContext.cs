using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexbookData.Models;

namespace FlexbookData.DataAccess
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions options) : base(options) { }
        public DbSet<Author> authors { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Address> address { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OrderItem> order_item { get; set; }
        public DbSet<Conversation> conversation { get; set; }
        public DbSet<Comment> comment { get; set; }
    }
}
