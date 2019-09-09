using Microsoft.EntityFrameworkCore;
using WolleWinkel.Persistence.Infrastructure;

namespace WolleWinkel.Persistence
{
    public class DbContextFactory : DesignTimeDbContextFactoryBase<DbContext>
    {
        protected override DbContext CreateNewInstance(DbContextOptions<DbContext> options)
        {
            return new DbContext(options);
        }
    }
}