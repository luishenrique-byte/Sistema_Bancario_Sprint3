using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Bancario_Sprint3.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNomeColunaCnpj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CpnjVinculado",
                table: "Contas",
                newName: "CnpjVinculado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CnpjVinculado",
                table: "Contas",
                newName: "CpnjVinculado");
        }
    }
}
