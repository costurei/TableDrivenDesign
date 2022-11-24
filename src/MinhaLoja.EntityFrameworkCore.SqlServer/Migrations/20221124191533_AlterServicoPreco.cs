using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaLoja.Migrations
{
    public partial class AlterServicoPreco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Servicos",
                newName: "PrecoValor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecoValor",
                table: "Servicos",
                newName: "Valor");
        }
    }
}
