using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financas.Migrations
{
    public partial class SetNewContaKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Contas_ContaId",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Metas_Contas_ContaId",
                table: "Metas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_ContaId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ContaId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Metas_ContaId",
                table: "Metas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_ContaId",
                table: "Despesas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contas",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Contas");

            migrationBuilder.AddColumn<string>(
                name: "ContaLogin",
                table: "Transacoes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaLogin",
                table: "Metas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaLogin",
                table: "Despesas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Contas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contas",
                table: "Contas",
                column: "Login");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ContaLogin",
                table: "Transacoes",
                column: "ContaLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Metas_ContaLogin",
                table: "Metas",
                column: "ContaLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_ContaLogin",
                table: "Despesas",
                column: "ContaLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Contas_ContaLogin",
                table: "Despesas",
                column: "ContaLogin",
                principalTable: "Contas",
                principalColumn: "Login");

            migrationBuilder.AddForeignKey(
                name: "FK_Metas_Contas_ContaLogin",
                table: "Metas",
                column: "ContaLogin",
                principalTable: "Contas",
                principalColumn: "Login");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_ContaLogin",
                table: "Transacoes",
                column: "ContaLogin",
                principalTable: "Contas",
                principalColumn: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Contas_ContaLogin",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Metas_Contas_ContaLogin",
                table: "Metas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_ContaLogin",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ContaLogin",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Metas_ContaLogin",
                table: "Metas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_ContaLogin",
                table: "Despesas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contas",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "ContaLogin",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "ContaLogin",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "ContaLogin",
                table: "Despesas");

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Transacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Metas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Despesas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contas",
                table: "Contas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ContaId",
                table: "Transacoes",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Metas_ContaId",
                table: "Metas",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_ContaId",
                table: "Despesas",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Contas_ContaId",
                table: "Despesas",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Metas_Contas_ContaId",
                table: "Metas",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_ContaId",
                table: "Transacoes",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id");
        }
    }
}
