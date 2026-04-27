using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Data.Mappings
{
    public class ContaEmpresarialMap : IEntityTypeConfiguration<ContaEmpresarial>
    {
        public void Configure(EntityTypeBuilder<ContaEmpresarial> builder)
        {
            builder.ToTable("Contas_Empresarial");
    
            builder.Property(c => c.CpnjVinculado)
                .IsRequired()
                .HasMaxLength(14);
    
            builder.Property(c => c.limiteCredito)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
        }
    }
}
