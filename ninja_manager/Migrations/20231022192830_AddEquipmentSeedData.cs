using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ninja_manager.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipmentSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "equipment",
                columns: new[] { "id", "agility", "category_name", "gold", "intelligence", "name", "strength" },
                values: new object[,]
                {
                    { 1, 10, "Head", 2.0, 2, "Straw Hat", 5 },
                    { 2, -5, "Head", 50.0, 10, "Iron Helmet", 27 },
                    { 3, -20, "Head", 140.0, 12, "Samurai Helmet", 75 },
                    { 4, 10, "Hands", 10.0, 1, "Wooden Sword", 10 },
                    { 5, 45, "Hands", 55.0, 3, "Steel Dagger", 53 },
                    { 6, 50, "Hands", 200.0, 2, "Ninja Katana", 200 },
                    { 7, 19, "Feet", 5.0, 1, "Sandals", -4 },
                    { 8, 43, "Feet", 50.0, 11, "Leather Boots", 12 },
                    { 9, 140, "Feet", 100.0, 20, "Ninja Boots", 32 },
                    { 10, 1, "Necklace", 2.0, 13, "Bead Necklace", -5 },
                    { 11, 10, "Necklace", 50.0, 26, "Amulet of Health", 0 },
                    { 12, 20, "Necklace", 100.0, 52, "Wisdom Amulet", 2 },
                    { 13, 0, "Chest", 10.0, 2, "Cloth Robe", 4 },
                    { 14, -8, "Chest", 50.0, 3, "Chainmail Armor", 40 },
                    { 15, -15, "Chest", 182.0, 7, "Dragon Scale Armor", 100 },
                    { 16, 10, "Ring", 10.0, 1, "Wooden Ring", 1 },
                    { 17, 40, "Ring", 80.0, 31, "Silver Ring", 52 },
                    { 18, 999, "Ring", 631.0, 999, "Ring of Power", 999 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "equipment",
                keyColumn: "id",
                keyValue: 18);
        }
    }
}
