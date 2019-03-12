using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanches.Web.Migrations
{
    public partial class DataEntregaPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PedidoEntregue",
                table: "Pedidos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PedidoEntregue",
                table: "Pedidos");
        }
    }
}
