using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sistema_Bancario_Sprint3.Migrations
{
    /// <inheritdoc />
    public partial class SeedDadosIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "DataCadastro", "Email", "Nome", "Telefone", "TipoPessoa", "cpfCnpj" },
                values: new object[,]
                {
                    { 20L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao@ubank.com", "João Silva", "(81) 99999-0001", 0, "11111111111" },
                    { 21L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria@ubank.com", "Maria Santos", "(81) 99999-0002", 0, "22222222222" },
                    { 22L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "empresa@ubank.com", "Tech Empresa Ltda", "(81) 99999-0003", 1, "00000000000100" }
                });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "Agencia", "CnpjVinculado", "DataAbertura", "DiaRendimento", "IdCliente", "IdTipoConta", "LimiteCredito", "NumeroConta", "Saldo", "Status", "TaxaJuros" },
                values: new object[,]
                {
                    { 20L, "0001", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20L, 1L, null, "1001", 1000.00m, "ativa", null },
                    { 21L, "0001", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 21L, 2L, null, "2002", 2000.00m, "ativa", 0.5m },
                    { 22L, "0001", "00000000000100", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 22L, 3L, 50000.00m, "3003", 5000.00m, "ativa", null }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataCriacao", "Email", "IdCliente", "SenhaHash", "Status" },
                values: new object[,]
                {
                    { 20L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao@ubank.com", 20L, "$2a$11$CS9lAe5X2fX61LBmblHaBOr13EN/CoeL8XnOzV.Fktv4goiPk3TOW", 1 },
                    { 21L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria@ubank.com", 21L, "$2a$11$A0vx5bNNOPW3prMi1z0gku//A8214tcA2r2gAU2DSYV2wD4HeowgG", 1 },
                    { 22L, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "empresa@ubank.com", 22L, "$2a$11$mBvpGArj5rA1GE3n01y7quAvjIn1mvngvqUtKRrUVGOiUEjJlcja2", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 22L);
        }
    }
}
