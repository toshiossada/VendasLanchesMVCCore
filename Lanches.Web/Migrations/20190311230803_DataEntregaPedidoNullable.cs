using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanches.Web.Migrations
{
    public partial class DataEntregaPedidoNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PedidoEntregue",
                table: "Pedidos",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PedidoEntregue",
                table: "Pedidos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
