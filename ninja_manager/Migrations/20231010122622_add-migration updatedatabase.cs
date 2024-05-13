using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ninja_manager.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationupdatedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__inventory__equip__3C69FB99",
                table: "inventory");

            migrationBuilder.DropForeignKey(
                name: "FK__inventory__ninja__3B75D760",
                table: "inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK__inventor__18BDFAEEC7A06D30",
                table: "inventory");

            migrationBuilder.DropColumn(
                name: "category",
                table: "equipment");

            migrationBuilder.AddColumn<string>(
                name: "category_name",
                table: "equipment",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory",
                table: "inventory",
                columns: new[] { "ninja_id", "equipment_id" });

            migrationBuilder.CreateTable(
                name: "categorie",
                columns: table => new
                {
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorie_1", x => x.name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_equipment_category_name",
                table: "equipment",
                column: "category_name");

            migrationBuilder.AddForeignKey(
                name: "FK_equipment_categorie",
                table: "equipment",
                column: "category_name",
                principalTable: "categorie",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_equipment",
                table: "inventory",
                column: "equipment_id",
                principalTable: "equipment",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_ninja",
                table: "inventory",
                column: "ninja_id",
                principalTable: "ninja",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipment_categorie",
                table: "equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_equipment",
                table: "inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_ninja",
                table: "inventory");

            migrationBuilder.DropTable(
                name: "categorie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory",
                table: "inventory");

            migrationBuilder.DropIndex(
                name: "IX_equipment_category_name",
                table: "equipment");

            migrationBuilder.DropColumn(
                name: "category_name",
                table: "equipment");

            migrationBuilder.AddColumn<double>(
                name: "category",
                table: "equipment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__inventor__18BDFAEEC7A06D30",
                table: "inventory",
                columns: new[] { "ninja_id", "equipment_id" });

            migrationBuilder.AddForeignKey(
                name: "FK__inventory__equip__3C69FB99",
                table: "inventory",
                column: "equipment_id",
                principalTable: "equipment",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__inventory__ninja__3B75D760",
                table: "inventory",
                column: "ninja_id",
                principalTable: "ninja",
                principalColumn: "id");
        }
    }
}
