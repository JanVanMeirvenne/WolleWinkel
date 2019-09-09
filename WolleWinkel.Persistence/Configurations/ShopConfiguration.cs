using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Persistence.Configurations
{
    public class ShopConfiguration:IEntityTypeConfiguration<ShopEntity>
    {
        public void Configure(EntityTypeBuilder<ShopEntity> builder)
        {
            builder.HasMany<ShopItemEntity>();
            builder.HasOne<CustomerEntity>();

        }
    }
}