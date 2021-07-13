using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazon2077backup.Migrations
{
    public partial class Tables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoIMG",
                table: "Carrito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductoIMG",
                table: "Carrito",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
