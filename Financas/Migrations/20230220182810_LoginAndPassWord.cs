using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financas.Migrations
{
    public partial class LoginAndPassWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Contas");
        }
    }
}
