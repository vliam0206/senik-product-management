using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentApis;

public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        #region for sqlserver
        //builder.Property(x => x.CreationDate).HasDefaultValueSql("getutcdate()");
        //builder.Property(x => x.ModificationDate).HasDefaultValueSql("getutcdate()");
        #endregion

        #region for postgresql
        builder.Property(x => x.CreationDate).HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()");
        builder.Property(x => x.ModificationDate).HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()");
        #endregion

        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
    }
}
