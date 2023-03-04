using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financas.Migrations
{
    public partial class DbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    DataCobranca = table.Column<DateTime>(type: "DATE", nullable: false),
                    PeriodoDeCobranca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    Realizada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Identificacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    TransacoesId = table.Column<int>(type: "int", nullable: true),
                    DespesasId = table.Column<int>(type: "int", nullable: true),
                    MetasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Despesas_DespesasId",
                        column: x => x.DespesasId,
                        principalTable: "Despesas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contas_Metas_MetasId",
                        column: x => x.MetasId,
                        principalTable: "Metas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contas_Transacoes_TransacoesId",
                        column: x => x.TransacoesId,
                        principalTable: "Transacoes",
                        principalColumn: "Id");
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Metas");

            migrationBuilder.DropTable(
                name: "Transacoes");
        }
    }
}
