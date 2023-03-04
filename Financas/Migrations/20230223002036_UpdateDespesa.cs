using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financas.Migrations
{
    public partial class UpdateDespesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeriodoDeCobranca",
                table: "Despesas",
                newName: "QntdParcelas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QntdParcelas",
                table: "Despesas",
                newName: "PeriodoDeCobranca");
        }
    }
}
