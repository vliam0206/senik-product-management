using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentApis;

public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.Property(x => x.CreationDate).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.ModificationDate).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
    }
}
