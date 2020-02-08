using Microsoft.EntityFrameworkCore.Migrations;

namespace BullMarket.Web.Migrations
{
    public partial class Ajustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorcentagemDesejado",
                table: "Corretagens");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Empresas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Empresas");

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentagemDesejado",
                table: "Corretagens",
                type: "decimal(18,8)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
