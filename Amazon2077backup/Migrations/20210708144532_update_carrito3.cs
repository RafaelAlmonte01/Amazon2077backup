using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazon2077backup.Migrations
{
    public partial class update_carrito3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PreUNI",
                table: "Carrito",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PreUNI",
                table: "Carrito",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
