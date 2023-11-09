using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("80a55152-a7d8-440a-921c-7d4187a4767f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("998658c3-d30d-49a3-a0ef-2c7151139ff9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("8a634208-318c-4f43-94ed-d4801d4130ff"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c3163d63-6c31-4f80-9950-ebd8b59c229d"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { new Guid("c0293586-af15-4319-9c49-efa44b3e8c50"), 1, "Action" },
                    { new Guid("d2782e33-9108-4e94-a93a-931ec1398265"), 2, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("18775f88-7bc7-41ec-a1ff-4b6ad9c5b9cf"), "Rabindranath Tagore", new Guid("c0293586-af15-4319-9c49-efa44b3e8c50"), "Early 20th century Indian Literature", "0123456789", "", 20.0, 13.0, 17.0, "Chokher Bali" },
                    { new Guid("4fc9aa2d-edec-4bb6-b940-37c881fd06e3"), "Neil Gaiman", new Guid("d2782e33-9108-4e94-a93a-931ec1398265"), "American Gods", "7894631", "", 20.0, 13.0, 17.0, "American Gods" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("18775f88-7bc7-41ec-a1ff-4b6ad9c5b9cf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("4fc9aa2d-edec-4bb6-b940-37c881fd06e3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c0293586-af15-4319-9c49-efa44b3e8c50"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("d2782e33-9108-4e94-a93a-931ec1398265"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

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
        }
    }
}
