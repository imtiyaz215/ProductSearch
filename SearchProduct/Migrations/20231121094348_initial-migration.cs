using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SearchProduct.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    MfgDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "MfgDate", "Price", "ProductName", "Size" },
                values: new object[,]
                {
                    { 1, "Economy", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, "Product1", "L" },
                    { 2, "Premium", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 112f, "Product2", "L" },
                    { 3, "Standard", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 120f, "Product3", "M" },
                    { 4, "Economy", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, "Product4", "S" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
