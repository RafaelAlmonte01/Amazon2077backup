using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazon2077backup.Migrations
{
    public partial class update_ProductoID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PID",
                table: "Carrito");

            migrationBuilder.AddColumn<int>(
                name: "ProductoID",
                table: "Carrito",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoID",
                table: "Carrito");

            migrationBuilder.AddColumn<int>(
                name: "PID",
                table: "Carrito",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
