using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.FluentApis;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        #region for sqlserver
        //builder.Property(x => x.CreationDate).HasDefaultValueSql("getutcdate()");
        //builder.Property(x => x.ModificationDate).HasDefaultValueSql("getutcdate()");
        //builder.Property(x => x.Id)
        //    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);
        #endregion

        #region for postgresql
        builder.Property(x => x.CreationDate).HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()");
        builder.Property(x => x.ModificationDate).HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()");
        builder.Property(x => x.Id)
            .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        #endregion

        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.TotalMoney).HasDefaultValue(0);
        builder.Property(x => x.TotalQuantity).HasDefaultValue(0);
        builder.Property(x => x.Status).HasDefaultValue(OrderStatusEnum.Waiting);

        builder.HasOne(x => x.CustomerInfor).WithMany(c => c.Orders).HasForeignKey(x => x.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);        
    }
}
