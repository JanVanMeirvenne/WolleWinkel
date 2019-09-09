using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Persistence.Configurations
{
    public class UserConfiguration:IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasMany<ShopItemEntity>();
            builder.HasOne<CustomerEntity>();

        }
    }
}