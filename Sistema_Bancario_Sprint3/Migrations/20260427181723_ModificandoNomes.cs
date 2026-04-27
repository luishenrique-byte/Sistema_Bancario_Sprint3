using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Bancario_Sprint3.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoNomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Clientes_IdCliente",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_TipoContas_IdTipoConta",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_FK_conta_destino",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_FK_conta_origem",
                table: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "FK_conta_origem",
                table: "Transacoes",
                newName: "IdContaOrigem");

            migrationBuilder.RenameColumn(
                name: "FK_conta_destino",
                table: "Transacoes",
                newName: "IdContaDestino");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_FK_conta_origem",
                table: "Transacoes",
                newName: "IX_Transacoes_IdContaOrigem");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_FK_conta_destino",
                table: "Transacoes",
                newName: "IX_Transacoes_IdContaDestino");

            migrationBuilder.AddForeignKey(
                name: "FK_cliente",
                table: "Contas",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tipo_conta",
                table: "Contas",
                column: "IdTipoConta",
                principalTable: "TipoContas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_conta_destino",
                table: "Transacoes",
                column: "IdContaDestino",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_conta_origem",
                table: "Transacoes",
                column: "IdContaOrigem",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cliente",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_tipo_conta",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_conta_destino",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_conta_origem",
                table: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "IdContaOrigem",
                table: "Transacoes",
                newName: "FK_conta_origem");

            migrationBuilder.RenameColumn(
                name: "IdContaDestino",
                table: "Transacoes",
                newName: "FK_conta_destino");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_IdContaOrigem",
                table: "Transacoes",
                newName: "IX_Transacoes_FK_conta_origem");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_IdContaDestino",
                table: "Transacoes",
                newName: "IX_Transacoes_FK_conta_destino");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Clientes_IdCliente",
                table: "Contas",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_TipoContas_IdTipoConta",
                table: "Contas",
                column: "IdTipoConta",
                principalTable: "TipoContas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_FK_conta_destino",
                table: "Transacoes",
                column: "FK_conta_destino",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_FK_conta_origem",
                table: "Transacoes",
                column: "FK_conta_origem",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
