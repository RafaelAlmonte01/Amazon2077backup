using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazon2077backup.Migrations
{
    public partial class update_username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Carrito");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Carrito",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Carrito");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Carrito",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
