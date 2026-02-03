using Microsoft.EntityFrameworkCore;
using MiniStore.Models;

namespace MiniStore.Data
{
    public class MiniStoreDbContext : DbContext
    {
        public MiniStoreDbContext(DbContextOptions<MiniStoreDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();

      

    }
}
