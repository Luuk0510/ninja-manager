using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ninja_manager.Migrations
{
    /// <inheritdoc />
    public partial class changedIventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "gold",
                table: "inventory",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "category_name",
                table: "equipment",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gold",
                table: "inventory");

            migrationBuilder.AlterColumn<string>(
                name: "category_name",
                table: "equipment",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldDefaultValueSql: "('')");
        }
    }
}
