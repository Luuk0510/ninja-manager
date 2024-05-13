using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ninja_manager.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categorie",
                column: "name",
                values: new object[]
                {
                    "Chest",
                    "Feet",
                    "Hands",
                    "Head",
                    "Necklace",
                    "Ring"
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categorie",
                keyColumn: "name",
                keyValue: "Chest");

            migrationBuilder.DeleteData(
                table: "categorie",
                keyColumn: "name",
                keyValue: "Feet");

            migrationBuilder.DeleteData(
                table: "categorie",
                keyColumn: "name",
                keyValue: "Hands");

            migrationBuilder.DeleteData(
                table: "categorie",
                keyColumn: "name",
                keyValue: "Head");

            migrationBuilder.DeleteData(
                table: "categorie",
                keyColumn: "name",
                keyValue: "Necklace");

            migrationBuilder.DeleteData(
                table: "categorie",
                keyColumn: "name",
                keyValue: "Ring");
        }
    }
}
