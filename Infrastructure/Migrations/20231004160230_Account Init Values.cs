using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AccountInitValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Address", "CreatedBy", "CreationDate", "DeletedBy", "DeletionDate", "Email", "FullName", "ModificationDate", "ModifiedBy", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown, USA", null, new DateTime(2023, 10, 4, 23, 2, 30, 533, DateTimeKind.Local).AddTicks(6569), null, null, "john.doe@example.com", "John Doe", new DateTime(2023, 10, 4, 23, 2, 30, 533, DateTimeKind.Local).AddTicks(6577), null, "SHkBLD0tFLhE5SUeeK4rSICJuzzZvvWhpPgLXacDKTHCzBoH", "123-456-7890", 1 },
                    { 2, "456 Elm St, Anycity, USA", null, new DateTime(2023, 10, 4, 23, 2, 30, 536, DateTimeKind.Local).AddTicks(8598), null, null, "alice.smith@example.com", "Alice Smith", new DateTime(2023, 10, 4, 23, 2, 30, 536, DateTimeKind.Local).AddTicks(8599), null, "57HJ/lXzppSYSpVm5RBxlodDP5rfKJRk/Sy12VdWZnx7hmG0", "987-654-3210", 1 },
                    { 3, null, null, new DateTime(2023, 10, 4, 23, 2, 30, 539, DateTimeKind.Local).AddTicks(9985), null, null, "lam@senik.com", "Staff Lam", new DateTime(2023, 10, 4, 23, 2, 30, 539, DateTimeKind.Local).AddTicks(9985), null, "/zF99XI/hhb4SvuM9uWVf4RjlQ9Tk5nSYsN0KCnTVsGwNwCl", null, 0 },
                    { 4, null, null, new DateTime(2023, 10, 4, 23, 2, 30, 543, DateTimeKind.Local).AddTicks(1626), null, null, "hoanganh@senik.com", "Staff Thông", new DateTime(2023, 10, 4, 23, 2, 30, 543, DateTimeKind.Local).AddTicks(1626), null, "ARBL3uk2VnC/acUpOfMultBlVFc0+iiEltWXaKBjA8q563Y3", null, 0 },
                    { 5, null, null, new DateTime(2023, 10, 4, 23, 2, 30, 546, DateTimeKind.Local).AddTicks(4063), null, null, "thong@senik.com", "Staff Hoàng Anh", new DateTime(2023, 10, 4, 23, 2, 30, 546, DateTimeKind.Local).AddTicks(4071), null, "4UimMbHvLSvSOQMexsrxlfXHkRp5Hifzfi7EZ4twckh+6HsD", null, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
