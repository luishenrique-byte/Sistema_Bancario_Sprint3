using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Bancario_Sprint3.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNomeColunaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiaRrendimento",
                table: "Contas",
                newName: "DiaRendimento");

            migrationBuilder.RenameColumn(
                name: "tipoPessoa",
                table: "Clientes",
                newName: "TipoPessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiaRendimento",
                table: "Contas",
                newName: "DiaRrendimento");

            migrationBuilder.RenameColumn(
                name: "TipoPessoa",
                table: "Clientes",
                newName: "tipoPessoa");
        }
    }
}
