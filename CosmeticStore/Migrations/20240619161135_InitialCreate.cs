using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CosmeticStore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Availability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Category = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ingredients = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<double>(type: "double", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsFeatured = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PromotionalPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Rating = table.Column<double>(type: "double", nullable: false),
                    NumberOfReviews = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Availability", "Category", "CreatedAt", "Description", "ImageUrl", "Ingredients", "IsFeatured", "Name", "NumberOfReviews", "Price", "PromotionalPrice", "Rating", "UpdatedAt", "Weight" },
                values: new object[,]
                {
                    { 1, false, "", new DateTime(2024, 6, 19, 16, 11, 34, 947, DateTimeKind.Utc).AddTicks(2987), "", "", "", false, "Product 1", 0, 10.00m, 0.0m, 0.0, new DateTime(2024, 6, 19, 16, 11, 34, 947, DateTimeKind.Utc).AddTicks(2988), 0.0 },
                    { 2, false, "", new DateTime(2024, 6, 19, 16, 11, 34, 947, DateTimeKind.Utc).AddTicks(2991), "", "", "", false, "Product 2", 0, 15.00m, 0.0m, 0.0, new DateTime(2024, 6, 19, 16, 11, 34, 947, DateTimeKind.Utc).AddTicks(2991), 0.0 }
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
