using Domain;
using Domain.Enums;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentApis;

public class AccountConfig : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.CreationDate).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.ModificationDate).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);

        builder.HasData(
            new Account { Id = 1, FullName = "John Doe", Email = "john.doe@example.com", Password = "@12345".Hash(), PhoneNumber = "123-456-7890", Address = "123 Main St, Anytown, USA", Role = AccountTypeEnum.Customer },
            new Account { Id = 2, FullName = "Alice Smith", Email = "alice.smith@example.com", Password = "@12345".Hash(), PhoneNumber = "987-654-3210", Address = "456 Elm St, Anycity, USA", Role = AccountTypeEnum.Customer },
            new Account { Id = 3, FullName = "Staff Lam", Email = "lam@senik.com", Password = "@12345".Hash(), Role = AccountTypeEnum.Staff },
            new Account { Id = 4, FullName = "Staff Hoàng Anh", Email = "hoanganh@senik.com", Password = "@12345".Hash(), Role = AccountTypeEnum.Staff },
            new Account { Id = 5, FullName = "Staff Thông", Email = "thong@senik.com", Password = "@12345".Hash(), Role = AccountTypeEnum.Staff }

        );
    }
}
