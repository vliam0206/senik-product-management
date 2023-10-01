using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentApis;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(x => x.CreationDate).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.ModificationDate).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.TotalMoney).HasDefaultValue(0);
        builder.Property(x => x.TotalQuantity).HasDefaultValue(0);
        builder.Property(x => x.Status).HasDefaultValue(OrderStatusEnum.Waiting);
    }
}
