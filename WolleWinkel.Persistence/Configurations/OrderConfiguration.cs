using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Persistence.Configurations
{
    public class OrderConfiguration:IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasMany<OrderItemEntity>();
            builder.HasOne<CustomerEntity>();

        }
    }
}