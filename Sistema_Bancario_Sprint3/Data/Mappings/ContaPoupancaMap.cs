using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Data.Mappings
{
    public class ContaPoupancaMap : IEntityTypeConfiguration<ContaPoupanca>
    {
        public void Configure(EntityTypeBuilder<ContaPoupanca> builder)
        {
            builder.ToTable("Contas_Poupanca");

            builder.Property(c => c.DiaRrendimento)
                .IsRequired();

            builder.Property(c => c.TaxaJuros)
                .HasPrecision(5, 2);
        }
    }
}
