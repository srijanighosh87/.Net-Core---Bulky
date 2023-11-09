using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changedsomemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { new Guid("2d3be734-5e92-45d8-af2c-c64133a57d42"), 2, "Sci-Fi" },
                    { new Guid("3aebd236-1805-4ae2-9c5c-17b20aea29fc"), 1, "Action" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("23e8a10b-2f31-4ef3-9c1a-e38b7e90f70f"), "Rabindranath Tagore", new Guid("3aebd236-1805-4ae2-9c5c-17b20aea29fc"), "Early 20th century Indian Literature", "0123456789", "", 20.0, 13.0, 17.0, "Chokher Bali" },
                    { new Guid("332d9c78-d643-4e3c-a4dc-d9b847738001"), "Neil Gaiman", new Guid("2d3be734-5e92-45d8-af2c-c64133a57d42"), "American Gods", "7894631", "", 20.0, 13.0, 17.0, "American Gods" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("23e8a10b-2f31-4ef3-9c1a-e38b7e90f70f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("332d9c78-d643-4e3c-a4dc-d9b847738001"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("2d3be734-5e92-45d8-af2c-c64133a57d42"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("3aebd236-1805-4ae2-9c5c-17b20aea29fc"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
