using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ninja_manager.Migrations
{
    /// <inheritdoc />
    public partial class newdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    category = table.Column<double>(type: "float", nullable: false),
                    strength = table.Column<int>(type: "int", nullable: false),
                    intelligence = table.Column<int>(type: "int", nullable: false),
                    agility = table.Column<int>(type: "int", nullable: false),
                    gold = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ninja",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    gold = table.Column<double>(type: "float", nullable: false),
                    strength = table.Column<int>(type: "int", nullable: false),
                    intelligence = table.Column<int>(type: "int", nullable: false),
                    agility = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ninja", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    ninja_id = table.Column<int>(type: "int", nullable: false),
                    equipment_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__inventor__18BDFAEEC7A06D30", x => new { x.ninja_id, x.equipment_id });
                    table.ForeignKey(
                        name: "FK__inventory__equip__3C69FB99",
                        column: x => x.equipment_id,
                        principalTable: "equipment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__inventory__ninja__3B75D760",
                        column: x => x.ninja_id,
                        principalTable: "ninja",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_equipment_id",
                table: "inventory",
                column: "equipment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "equipment");

            migrationBuilder.DropTable(
                name: "ninja");
        }
    }
}
