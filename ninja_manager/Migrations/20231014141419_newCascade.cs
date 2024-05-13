using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ninja_manager.Migrations
{
    /// <inheritdoc />
    public partial class newCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_ninja",
                table: "inventory");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_ninja",
                table: "inventory",
                column: "ninja_id",
                principalTable: "ninja",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_ninja",
                table: "inventory");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_ninja",
                table: "inventory",
                column: "ninja_id",
                principalTable: "ninja",
                principalColumn: "id");
        }
    }
}
