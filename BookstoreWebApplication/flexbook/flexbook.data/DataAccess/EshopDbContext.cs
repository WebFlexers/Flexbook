using Flexbook.Data.Models.BanManagement;
using Flexbook.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Flexbook.Data.DataAccess
{
    public class EshopDbContext : DbContext
    {
        public EshopDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BanList> BanList { get; set; }
    }
}