using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyCategoryToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ISBN = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Price50 = table.Column<double>(type: "double precision", nullable: false),
                    Price100 = table.Column<double>(type: "double precision", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { new Guid("8a634208-318c-4f43-94ed-d4801d4130ff"), 1, "Action" },
                    { new Guid("c3163d63-6c31-4f80-9950-ebd8b59c229d"), 2, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Author", "CategoryId", "Description", "ISBN", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("80a55152-a7d8-440a-921c-7d4187a4767f"), "Neil Gaiman", new Guid("c3163d63-6c31-4f80-9950-ebd8b59c229d"), "American Gods", "7894631", 20.0, 13.0, 17.0, "American Gods" },
                    { new Guid("998658c3-d30d-49a3-a0ef-2c7151139ff9"), "Rabindranath Tagore", new Guid("8a634208-318c-4f43-94ed-d4801d4130ff"), "Early 20th century Indian Literature", "0123456789", 20.0, 13.0, 17.0, "Chokher Bali" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
