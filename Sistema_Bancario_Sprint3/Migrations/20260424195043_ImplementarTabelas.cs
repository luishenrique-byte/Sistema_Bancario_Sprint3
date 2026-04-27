using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Bancario_Sprint3.Migrations
{
    /// <inheritdoc />
    public partial class ImplementarTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Clientes_ClienteId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_ContaDestinoId",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_ContaOrigemId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ContaDestinoId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ContaOrigemId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Contas_ClienteId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "ContaDestinoId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "ContaOrigemId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "CpnjVinculado",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "DiaRrendimento",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "TaxaJuros",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "limiteCredito",
                table: "Contas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Transacoes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<long>(
                name: "FK_conta_origem",
                table: "Transacoes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "FK_conta_destino",
                table: "Transacoes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHora",
                table: "Transacoes",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "TipoConta",
                table: "Contas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Contas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo",
                table: "Contas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroConta",
                table: "Contas",
                type: "varchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "IdCliente",
                table: "Contas",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAbertura",
                table: "Contas",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "Agencia",
                table: "Contas",
                type: "varchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Contas",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Clientes",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.CreateTable(
                name: "Contas_Corrente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas_Corrente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Corrente_Contas_Id",
                        column: x => x.Id,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contas_Empresarial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CpnjVinculado = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    limiteCredito = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas_Empresarial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Empresarial_Contas_Id",
                        column: x => x.Id,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contas_Poupanca",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DiaRrendimento = table.Column<int>(type: "int", nullable: false),
                    TaxaJuros = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas_Poupanca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Poupanca_Contas_Id",
                        column: x => x.Id,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_FK_conta_destino",
                table: "Transacoes",
                column: "FK_conta_destino");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_FK_conta_origem",
                table: "Transacoes",
                column: "FK_conta_origem");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Clientes_Id",
                table: "Contas",
                column: "Id",
                principalTable: "Clientes",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Clientes_Id",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_FK_conta_destino",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_FK_conta_origem",
                table: "Transacoes");

            migrationBuilder.DropTable(
                name: "Contas_Corrente");

            migrationBuilder.DropTable(
                name: "Contas_Empresarial");

            migrationBuilder.DropTable(
                name: "Contas_Poupanca");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_FK_conta_destino",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_FK_conta_origem",
                table: "Transacoes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Transacoes",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "FK_conta_origem",
                table: "Transacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "FK_conta_destino",
                table: "Transacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHora",
                table: "Transacoes",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<long>(
                name: "ContaDestinoId",
                table: "Transacoes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ContaOrigemId",
                table: "Transacoes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "TipoConta",
                table: "Contas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Contas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo",
                table: "Contas",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroConta",
                table: "Contas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(4)",
                oldMaxLength: 4)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "Contas",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAbertura",
                table: "Contas",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<string>(
                name: "Agencia",
                table: "Contas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(4)",
                oldMaxLength: 4)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Contas",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "ClienteId",
                table: "Contas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CpnjVinculado",
                table: "Contas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DiaRrendimento",
                table: "Contas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Contas",
                type: "varchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxaJuros",
                table: "Contas",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "limiteCredito",
                table: "Contas",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Clientes",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ContaDestinoId",
                table: "Transacoes",
                column: "ContaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ContaOrigemId",
                table: "Transacoes",
                column: "ContaOrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_ClienteId",
                table: "Contas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Clientes_ClienteId",
                table: "Contas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_ContaDestinoId",
                table: "Transacoes",
                column: "ContaDestinoId",
                principalTable: "Contas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_ContaOrigemId",
                table: "Transacoes",
                column: "ContaOrigemId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
