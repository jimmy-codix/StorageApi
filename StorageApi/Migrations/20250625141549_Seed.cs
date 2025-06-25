using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StorageApi.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Count", "Description", "Name", "Price", "Shelf" },
                values: new object[,]
                {
                    { 1, "Furniture", 1, "Nice chair.", "Chair", 100, "A2" },
                    { 2, "Vehicle", 5, "Goodyear Tire.", "Tire", 500, "F1" },
                    { 3, "Clothes", 5, "Blue shirt.", "Shirt", 25, "Q8" },
                    { 4, "Clothes", 10, "Black jacket.", "Jacket", 350, "Q9" },
                    { 5, "Animals", 100, "A whistle for your dog.", "Dog whistle", 10, "B12" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
