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
        public DbSet<Book> books { get; set; }
    }
}
