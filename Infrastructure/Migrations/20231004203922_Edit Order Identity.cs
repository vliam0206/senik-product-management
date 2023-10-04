using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditOrderIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 637, DateTimeKind.Local).AddTicks(8397), new DateTime(2023, 10, 5, 3, 39, 22, 637, DateTimeKind.Local).AddTicks(8408), "pIbiq9ROsk153rS9d4IeXgUd3hI7s6Y6yW5ZkevRwsZt3YhC" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 641, DateTimeKind.Local).AddTicks(1419), new DateTime(2023, 10, 5, 3, 39, 22, 641, DateTimeKind.Local).AddTicks(1428), "wT399xovW/5QZpQYDAMc+zolN2lVHqrwl3UKK48vC67wxT5F" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 644, DateTimeKind.Local).AddTicks(2735), new DateTime(2023, 10, 5, 3, 39, 22, 644, DateTimeKind.Local).AddTicks(2736), "Va+gFez4j1r7pIbfAwOuY0Tq0IivQPrLXk8zwmqNCceVsqHY" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "FullName", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 647, DateTimeKind.Local).AddTicks(4383), "Staff Hoàng Anh", new DateTime(2023, 10, 5, 3, 39, 22, 647, DateTimeKind.Local).AddTicks(4383), "Mg8FmD61VwMXmjyIamvTkUaHNLj59hUatBP3/o7c6BqcQfQP" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "FullName", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 650, DateTimeKind.Local).AddTicks(6055), "Staff Thông", new DateTime(2023, 10, 5, 3, 39, 22, 650, DateTimeKind.Local).AddTicks(6055), "tPPJWChEAW18FexXKDZMVLBZ4ZkjzmbQIF9BBnX38Kk8M8UT" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3781), new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3792) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3794), new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3795) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3796), new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3797) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3798), new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3798) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3800), new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3802), new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3802) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3804), new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3804) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3806), new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3806) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3807), new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3808) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3809), new DateTime(2023, 10, 5, 3, 39, 22, 655, DateTimeKind.Local).AddTicks(3810) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 688, DateTimeKind.Local).AddTicks(6831), new DateTime(2023, 10, 4, 23, 32, 15, 688, DateTimeKind.Local).AddTicks(6843), "WhqByxQiOClrpxqoTH+a+8VlyEtzgiv5S3ZvAiRxtLne1j1h" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 691, DateTimeKind.Local).AddTicks(8425), new DateTime(2023, 10, 4, 23, 32, 15, 691, DateTimeKind.Local).AddTicks(8427), "+muicEPN2EOnp/NEZq/Sba2rd9zcHeoMiVLcuLsEKfsmLGl2" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 694, DateTimeKind.Local).AddTicks(9773), new DateTime(2023, 10, 4, 23, 32, 15, 694, DateTimeKind.Local).AddTicks(9774), "XFwPdzvM+hootR3M9xJ05uuAXnhhDK+XfWWg4jfgu4XjDsci" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "FullName", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 698, DateTimeKind.Local).AddTicks(727), "Staff Thông", new DateTime(2023, 10, 4, 23, 32, 15, 698, DateTimeKind.Local).AddTicks(727), "Lgk42XAQhQ1sA1/MsvXNM0EBcUridSxtUffeXGRkOPOcdI2f" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "FullName", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 701, DateTimeKind.Local).AddTicks(2219), "Staff Hoàng Anh", new DateTime(2023, 10, 4, 23, 32, 15, 701, DateTimeKind.Local).AddTicks(2221), "SkKxrrXvFGzzUqMssknSPfvHybVdlA22SKQhZEXU9KYwrpDq" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3093), new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3109) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3112), new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3113) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3114), new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3115) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3116), new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3116) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3118), new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3118) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3120), new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3122), new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3122) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3124), new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3124) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3126), new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3126) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3127), new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3128) });
        }
    }
}
