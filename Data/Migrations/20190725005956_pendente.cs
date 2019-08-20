using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoMarcado.WebApp.Data.Migrations
{
    public partial class pendente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SalarioBase",
                table: "Funcionario",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalarioBase",
                table: "Funcionario");
        }
    }
}
