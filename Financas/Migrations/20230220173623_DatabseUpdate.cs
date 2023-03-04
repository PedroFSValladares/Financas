using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financas.Migrations
{
    public partial class DatabseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Despesas_DespesasId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Metas_MetasId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Transacoes_TransacoesId",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_DespesasId",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_MetasId",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_TransacoesId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "DespesasId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "MetasId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "TransacoesId",
                table: "Contas");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Despesas");

            migrationBuilder.AddColumn<int>(
                name: "DespesasId",
                table: "Contas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MetasId",
                table: "Contas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransacoesId",
                table: "Contas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_DespesasId",
                table: "Contas",
                column: "DespesasId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_MetasId",
                table: "Contas",
                column: "MetasId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_TransacoesId",
                table: "Contas",
                column: "TransacoesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Despesas_DespesasId",
                table: "Contas",
                column: "DespesasId",
                principalTable: "Despesas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Metas_MetasId",
                table: "Contas",
                column: "MetasId",
                principalTable: "Metas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Transacoes_TransacoesId",
                table: "Contas",
                column: "TransacoesId",
                principalTable: "Transacoes",
                principalColumn: "Id");
        }
    }
}
