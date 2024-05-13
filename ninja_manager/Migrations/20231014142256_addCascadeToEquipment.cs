using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ninja_manager.Migrations
{
    /// <inheritdoc />
    public partial class addCascadeToEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_equipment",
                table: "inventory");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_equipment",
                table: "inventory",
                column: "equipment_id",
                principalTable: "equipment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_equipment",
                table: "inventory");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_equipment",
                table: "inventory",
                column: "equipment_id",
                principalTable: "equipment",
                principalColumn: "id");
        }
    }
}
