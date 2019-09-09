using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<ShopEntity> Shops { get; set; }
        DbSet<OrderEntity> Orders { get; set; }
        DbSet<CustomerEntity> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}