using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BullMarket.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Ramo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Corretagens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCompra = table.Column<DateTime>(nullable: false),
                    Corretora = table.Column<string>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    ValorCompra = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    ValorAgora = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    PorcentagemDesejado = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    Custos = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    Status = table.Column<string>(nullable: false),
                    AcaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corretagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corretagens_Empresas_AcaoId",
                        column: x => x.AcaoId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corretagens_AcaoId",
                table: "Corretagens",
                column: "AcaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corretagens");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
