using WolleWinkel.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Persistence
{
    public class DbContext:Microsoft.EntityFrameworkCore.DbContext,IDbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
            
        }
        public DbSet<ShopEntity> Shops { get; set; }
        
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}