using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PostgresqlMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    TotalMoney = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    TotalQuantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ShippedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Address", "CreatedBy", "CreationDate", "DeletedBy", "DeletionDate", "Email", "FullName", "ModificationDate", "ModifiedBy", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown, USA", null, new DateTime(2023, 10, 16, 3, 26, 8, 863, DateTimeKind.Local).AddTicks(2641), null, null, "john.doe@example.com", "John Doe", new DateTime(2023, 10, 16, 3, 26, 8, 863, DateTimeKind.Local).AddTicks(2655), null, "ETlFRU2FmQtp+wXSQk1rQaRsQtA2IdyLvBd1NDScmxelN3Oy", "123-456-7890", 1 },
                    { 2, "456 Elm St, Anycity, USA", null, new DateTime(2023, 10, 16, 3, 26, 8, 866, DateTimeKind.Local).AddTicks(7365), null, null, "alice.smith@example.com", "Alice Smith", new DateTime(2023, 10, 16, 3, 26, 8, 866, DateTimeKind.Local).AddTicks(7370), null, "oaLJu/C5yZDfpyI3PijhkZ2VArZKYtEtyZ7LFgQq0JfypM+d", "987-654-3210", 1 },
                    { 3, null, null, new DateTime(2023, 10, 16, 3, 26, 8, 869, DateTimeKind.Local).AddTicks(8559), null, null, "lam@senik.com", "Staff Lam", new DateTime(2023, 10, 16, 3, 26, 8, 869, DateTimeKind.Local).AddTicks(8560), null, "swk3kNlcBRvhu4Zy0zTqUX7BZafUO0Wa8CgxjsLrjYiHELAw", null, 0 },
                    { 4, null, null, new DateTime(2023, 10, 16, 3, 26, 8, 873, DateTimeKind.Local).AddTicks(7277), null, null, "hoanganh@senik.com", "Staff Hoàng Anh", new DateTime(2023, 10, 16, 3, 26, 8, 873, DateTimeKind.Local).AddTicks(7306), null, "1jRgnRqtz9VVTf/QSjfK6G79ceG/vyKLjqdYqBewviQ7FknN", null, 0 },
                    { 5, null, null, new DateTime(2023, 10, 16, 3, 26, 8, 878, DateTimeKind.Local).AddTicks(2351), null, null, "thong@senik.com", "Staff Thông", new DateTime(2023, 10, 16, 3, 26, 8, 878, DateTimeKind.Local).AddTicks(2354), null, "GSBoZzaHNgqKkLK/50ki6DgTLX5zcCMlCtMsn59RshazYJJb", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedBy", "CreationDate", "DeletedBy", "DeletionDate", "Description", "Image", "ModificationDate", "ModifiedBy", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8836), null, null, "A stunning succulent that glows like the moonlight.", "https://th.bing.com/th/id/OIP.xMeFmNxgcpdd5sXMfXIi-gHaE7?pid=ImgDet&w=800&h=533&rs=1", new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8854), null, "Mystical Moonlight Succulent", 97000.0, 50 },
                    { 2, 0, null, new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8856), null, null, "An illusionary cactus that appears to shimmer in the desert sun.", "https://th.bing.com/th/id/OIP.hNc2N9iLljV8VMWx_BHJ7QEDDw?pid=ImgDet&rs=1", new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8856), null, "Desert Mirage Cactus", 12000.0, 30 },
                    { 3, 3, null, new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8857), null, null, "Create a magical atmosphere with these enchanting fairy lights", "https://th.bing.com/th/id/OIP.2Kpj8zaosbOUIfX0AmSlMgHaHa?pid=ImgDet&rs=1", new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8858), null, "Enchanted Forest Fairy Lights", 75000.0, 20 },
                    { 4, 1, null, new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8859), null, null, "A succulent that resembles the fiery scales of a dragon.", "https://th.bing.com/th/id/OIP.YPEnYKS5Od0Hk2c5x6MH4QHaE8?pid=ImgDet&rs=1", new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8860), null, "Fire Dragon Succulent", 86000.0, 45 },
                    { 5, 2, null, new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8861), null, null, "A beautifully crafted glass vase inspired by the ocean.", "https://i.pinimg.com/originals/ce/ef/a2/ceefa2a3524afedbe6d99fa19bacd437.jpg", new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8862), null, "Ocean Breeze Glass Vase", 55000.0, 15 },
                    { 6, 3, null, new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8863), null, null, "A cactus that emits a neon-like glow in the dark.", "https://th.bing.com/th/id/R.b8d267e5efaf29425e5b7747cc6fd413?rik=Dj%2fXfb2WHH53wg&riu=http%3a%2f%2fstatic1.squarespace.com%2fstatic%2f51a79166e4b01ba7ba19a0f6%2ft%2f56f9e1101330bacc0f95b928%2f1459216677818%2f&ehk=IAXClID1p4n%2f%2bopYz6b6PwqITx0R9RveUHC1EjxJLFc%3d&risl=&pid=ImgRaw&r=0", new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8863), null, "Neon Glow Cactus", 11000.0, 28 },
                    { 7, 1, null, new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8865), null, null, "Create your own starry night with this succulent garden.", "https://i.pinimg.com/736x/37/2f/9f/372f9fa78e0cdf9b0141bce4dfc7dd23.jpg", new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8865), null, "Starry Night Succulent Garden", 275000.0, 40 },
                    { 8, 3, null, new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8867), null, null, "A crystal-clear globe that adds elegance to your decor.", "https://th.bing.com/th/id/OIP.sJ0mfVF7ptta-BZmzhAcjgAAAA?pid=ImgDet&rs=1", new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8867), null, "Crystal Clear Decorative Globe", 55000.0, 22 },
                    { 9, 2, null, new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8869), null, null, "An elegantly designed crystal vase fit for royalty.", "https://a.1stdibscdn.com/archivesE/upload/7977/26_15/2493352/2493352_l.jpeg", new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8869), null, "Royal Elegance Crystal Vase", 65000.0, 18 },
                    { 10, 0, null, new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8871), null, null, "A rugged cactus reminiscent of the wild west landscapes.", "https://th.bing.com/th/id/OIP.ez7XcMIuvhJd8LERpka5CwHaE7?pid=ImgDet&rs=1", new DateTime(2023, 10, 16, 3, 26, 8, 882, DateTimeKind.Local).AddTicks(8871), null, "Wild West Prickly Pear Cactus", 75000.0, 35 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
