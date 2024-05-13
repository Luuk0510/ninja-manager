using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ninja_manager.Migrations
{
    /// <inheritdoc />
    public partial class changeNinja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "agility",
                table: "ninja");

            migrationBuilder.DropColumn(
                name: "intelligence",
                table: "ninja");

            migrationBuilder.DropColumn(
                name: "strength",
                table: "ninja");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "agility",
                table: "ninja",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "intelligence",
                table: "ninja",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "strength",
                table: "ninja",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
