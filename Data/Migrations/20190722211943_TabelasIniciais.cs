using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoMarcado.WebApp.Data.Migrations
{
    public partial class TabelasIniciais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    MacAddress = table.Column<string>(nullable: false),
                    NomeDominio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.MacAddress);
                });

            migrationBuilder.CreateTable(
                name: "RegistroPonto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeUsuario = table.Column<string>(nullable: true),
                    MaquinaMacAddress = table.Column<string>(nullable: true),
                    HorarioRegistro = table.Column<DateTime>(nullable: false),
                    AlteracaoSessao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroPonto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroPonto_Maquina_MaquinaMacAddress",
                        column: x => x.MaquinaMacAddress,
                        principalTable: "Maquina",
                        principalColumn: "MacAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPonto_MaquinaMacAddress",
                table: "RegistroPonto",
                column: "MaquinaMacAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroPonto");

            migrationBuilder.DropTable(
                name: "Maquina");
        }
    }
}
