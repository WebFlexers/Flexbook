using Flexbook.Data.Models.BanManagement;
using Flexbook.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Flexbook.Data.DataAccess
{
    public class EshopDbContext : DbContext
    {
        public EshopDbContext(DbContextOptions options) : base(options) { }
    }
}