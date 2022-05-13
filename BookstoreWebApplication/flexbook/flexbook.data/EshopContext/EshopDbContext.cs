using Flexbook.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Flexbook.Data.EshopContext
{
    public class EshopDbContext : DbContext
    {
        public EshopDbContext(DbContextOptions options) : base(options) { }
        DbSet<Admin> Admins { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Customer> Customers { get; set; }
    }
}
