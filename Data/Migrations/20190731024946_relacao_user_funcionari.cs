using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoMarcado.WebApp.Data.Migrations
{
    public partial class relacao_user_funcionari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_AspNetUsers_UserId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_UserId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Funcionario",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Funcionario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_UsuarioId",
                table: "Funcionario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_AspNetUsers_UsuarioId",
                table: "Funcionario",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_AspNetUsers_UsuarioId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_UsuarioId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Funcionario");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Funcionario",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_UserId",
                table: "Funcionario",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_AspNetUsers_UserId",
                table: "Funcionario",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
