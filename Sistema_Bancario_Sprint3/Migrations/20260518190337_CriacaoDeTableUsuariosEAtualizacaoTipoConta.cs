using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sistema_Bancario_Sprint3.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDeTableUsuariosEAtualizacaoTipoConta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. 👇 ADICIONE ISTO NO INÍCIO DO MÉTODO UP
            // Remove a chave estrangeira temporariamente para que o MySQL permita alterar a tabela
            migrationBuilder.DropForeignKey(
                name: "FK_tipo_conta",
                table: "Contas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoContas",
                table: "TipoContas");

            migrationBuilder.RenameTable(
                name: "TipoContas",
                newName: "Tipos_Contas");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Tipos_Contas",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipos_Contas",
                table: "Tipos_Contas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SenhaHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", maxLength: 30, nullable: false, defaultValue: 0),
                    Status = table.Column<int>(type: "int", maxLength: 30, nullable: false, defaultValue: 0),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    IdCliente = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Cliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Tipos_Contas",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1L, "Corrente" },
                    { 2L, "Poupança" },
                    { 3L, "Empresarial" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdCliente",
                table: "Usuarios",
                column: "IdCliente");

            // 2. 👇 ADICIONE ISTO NO FINAL DO MÉTODO UP
            // Recria a chave estrangeira a apontar para a nova tabela renomeada "Tipos_Contas"
            migrationBuilder.AddForeignKey(
                name: "FK_tipo_conta",
                table: "Contas",
                column: "IdTipoConta",
                principalTable: "Tipos_Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 3. 👇 ADICIONE ISTO NO INÍCIO DO MÉTODO DOWN
            // Remove a chave estrangeira antes de tentar reverter a tabela
            migrationBuilder.DropForeignKey(
                name: "FK_tipo_conta",
                table: "Contas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipos_Contas",
                table: "Tipos_Contas");

            migrationBuilder.DeleteData(
                table: "Tipos_Contas",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Tipos_Contas",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Tipos_Contas",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.RenameTable(
                name: "Tipos_Contas",
                newName: "TipoContas");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TipoContas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoContas",
                table: "TipoContas",
                column: "Id");

            // 4. 👇 ADICIONE ISTO NO FINAL DO MÉTODO DOWN
            // Recria a chave estrangeira a apontar de volta para o nome antigo "TipoContas"
            migrationBuilder.AddForeignKey(
                name: "FK_tipo_conta",
                table: "Contas",
                column: "IdTipoConta",
                principalTable: "TipoContas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
