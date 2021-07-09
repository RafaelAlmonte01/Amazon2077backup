using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazon2077backup.Migrations
{
    public partial class update_decimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PreUNI",
                table: "Carrito",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PreUNI",
                table: "Carrito",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
