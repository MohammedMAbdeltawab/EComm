using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EComm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProducandCategoryEnities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });


            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreationTime", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 18, 23, 49, 21, 0, DateTimeKind.Utc), "Electronic Machines", false, "Electronics" },
                    { 2, new DateTime(2025, 10, 18, 23, 49, 21, 0, DateTimeKind.Utc), "Mix Books", false, "Books" },
                    { 3, new DateTime(2025, 10, 18, 23, 49, 21, 0, DateTimeKind.Utc), "Men and women Clothes", false, "Fashion" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "CreationTime", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Electronics", new DateTime(2025, 10, 18, 23, 49, 21, 0, DateTimeKind.Utc), "Samsung Flagship", "Image1.PNG", false, "Samsung S25 Ultra", 1000m, 50 },
                    { 2, "Books", new DateTime(2025, 10, 18, 23, 49, 21, 0, DateTimeKind.Utc), "adventure Manga", "Image1.PNG", false, "Attack On Titan", 20m, 100 },
                    { 3, "Fashion", new DateTime(2025, 10, 18, 23, 49, 21, 0, DateTimeKind.Utc), "Sprot T-Shirt", "Image1.PNG", false, "Messi T-Shirt", 40m, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
