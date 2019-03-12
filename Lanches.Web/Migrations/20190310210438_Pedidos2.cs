using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanches.Web.Migrations
{
    public partial class Pedidos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefonw",
                table: "Pedidos",
                newName: "Telefone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Pedidos",
                newName: "Telefonw");
        }
    }
}
