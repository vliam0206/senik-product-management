using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductInitValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 698, DateTimeKind.Local).AddTicks(727), new DateTime(2023, 10, 4, 23, 32, 15, 698, DateTimeKind.Local).AddTicks(727), "Lgk42XAQhQ1sA1/MsvXNM0EBcUridSxtUffeXGRkOPOcdI2f" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 32, 15, 701, DateTimeKind.Local).AddTicks(2219), new DateTime(2023, 10, 4, 23, 32, 15, 701, DateTimeKind.Local).AddTicks(2221), "SkKxrrXvFGzzUqMssknSPfvHybVdlA22SKQhZEXU9KYwrpDq" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedBy", "CreationDate", "DeletedBy", "DeletionDate", "Description", "Image", "ModificationDate", "ModifiedBy", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3093), null, null, "A stunning succulent that glows like the moonlight.", "https://th.bing.com/th/id/OIP.xMeFmNxgcpdd5sXMfXIi-gHaE7?pid=ImgDet&w=800&h=533&rs=1", new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3109), null, "Mystical Moonlight Succulent", 97000.0, 50 },
                    { 2, 0, null, new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3112), null, null, "An illusionary cactus that appears to shimmer in the desert sun.", "https://th.bing.com/th/id/OIP.hNc2N9iLljV8VMWx_BHJ7QEDDw?pid=ImgDet&rs=1", new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3113), null, "Desert Mirage Cactus", 12000.0, 30 },
                    { 3, 3, null, new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3114), null, null, "Create a magical atmosphere with these enchanting fairy lights", "https://th.bing.com/th/id/OIP.2Kpj8zaosbOUIfX0AmSlMgHaHa?pid=ImgDet&rs=1", new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3115), null, "Enchanted Forest Fairy Lights", 75000.0, 20 },
                    { 4, 1, null, new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3116), null, null, "A succulent that resembles the fiery scales of a dragon.", "https://th.bing.com/th/id/OIP.YPEnYKS5Od0Hk2c5x6MH4QHaE8?pid=ImgDet&rs=1", new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3116), null, "Fire Dragon Succulent", 86000.0, 45 },
                    { 5, 2, null, new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3118), null, null, "A beautifully crafted glass vase inspired by the ocean.", "https://i.pinimg.com/originals/ce/ef/a2/ceefa2a3524afedbe6d99fa19bacd437.jpg", new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3118), null, "Ocean Breeze Glass Vase", 55000.0, 15 },
                    { 6, 3, null, new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3120), null, null, "A cactus that emits a neon-like glow in the dark.", "https://th.bing.com/th/id/R.b8d267e5efaf29425e5b7747cc6fd413?rik=Dj%2fXfb2WHH53wg&riu=http%3a%2f%2fstatic1.squarespace.com%2fstatic%2f51a79166e4b01ba7ba19a0f6%2ft%2f56f9e1101330bacc0f95b928%2f1459216677818%2f&ehk=IAXClID1p4n%2f%2bopYz6b6PwqITx0R9RveUHC1EjxJLFc%3d&risl=&pid=ImgRaw&r=0", new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3120), null, "Neon Glow Cactus", 11000.0, 28 },
                    { 7, 1, null, new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3122), null, null, "Create your own starry night with this succulent garden.", "https://i.pinimg.com/736x/37/2f/9f/372f9fa78e0cdf9b0141bce4dfc7dd23.jpg", new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3122), null, "Starry Night Succulent Garden", 275000.0, 40 },
                    { 8, 3, null, new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3124), null, null, "A crystal-clear globe that adds elegance to your decor.", "https://th.bing.com/th/id/OIP.sJ0mfVF7ptta-BZmzhAcjgAAAA?pid=ImgDet&rs=1", new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3124), null, "Crystal Clear Decorative Globe", 55000.0, 22 },
                    { 9, 2, null, new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3126), null, null, "An elegantly designed crystal vase fit for royalty.", "https://a.1stdibscdn.com/archivesE/upload/7977/26_15/2493352/2493352_l.jpeg", new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3126), null, "Royal Elegance Crystal Vase", 65000.0, 18 },
                    { 10, 0, null, new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3127), null, null, "A rugged cactus reminiscent of the wild west landscapes.", "https://th.bing.com/th/id/OIP.ez7XcMIuvhJd8LERpka5CwHaE7?pid=ImgDet&rs=1", new DateTime(2023, 10, 4, 23, 32, 15, 706, DateTimeKind.Local).AddTicks(3128), null, "Wild West Prickly Pear Cactus", 75000.0, 35 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 2, 30, 533, DateTimeKind.Local).AddTicks(6569), new DateTime(2023, 10, 4, 23, 2, 30, 533, DateTimeKind.Local).AddTicks(6577), "SHkBLD0tFLhE5SUeeK4rSICJuzzZvvWhpPgLXacDKTHCzBoH" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 2, 30, 536, DateTimeKind.Local).AddTicks(8598), new DateTime(2023, 10, 4, 23, 2, 30, 536, DateTimeKind.Local).AddTicks(8599), "57HJ/lXzppSYSpVm5RBxlodDP5rfKJRk/Sy12VdWZnx7hmG0" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 2, 30, 539, DateTimeKind.Local).AddTicks(9985), new DateTime(2023, 10, 4, 23, 2, 30, 539, DateTimeKind.Local).AddTicks(9985), "/zF99XI/hhb4SvuM9uWVf4RjlQ9Tk5nSYsN0KCnTVsGwNwCl" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 2, 30, 543, DateTimeKind.Local).AddTicks(1626), new DateTime(2023, 10, 4, 23, 2, 30, 543, DateTimeKind.Local).AddTicks(1626), "ARBL3uk2VnC/acUpOfMultBlVFc0+iiEltWXaKBjA8q563Y3" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "ModificationDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 4, 23, 2, 30, 546, DateTimeKind.Local).AddTicks(4063), new DateTime(2023, 10, 4, 23, 2, 30, 546, DateTimeKind.Local).AddTicks(4071), "4UimMbHvLSvSOQMexsrxlfXHkRp5Hifzfi7EZ4twckh+6HsD" });
        }
    }
}
