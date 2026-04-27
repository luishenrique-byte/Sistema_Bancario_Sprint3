using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlConnector;
using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Data.Mappings
{
    public class ContaCorrenteMap : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.ToTable("Contas_Corrente");            
        }
    }
}
