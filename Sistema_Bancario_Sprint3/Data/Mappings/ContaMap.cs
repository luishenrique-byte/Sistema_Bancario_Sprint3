using Microsoft.EntityFrameworkCore;
using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Data.Mappings
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Contas");
            
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NumeroConta)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(c => c.Agencia)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(c => c.Saldo)
                .HasPrecision(18,2)
                .HasDefaultValue(0);

            builder.Property(c => c.Status)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(c => c.DataAbertura)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            builder.HasOne(c => c.Cliente)
                .WithMany(cl => cl.Contas)
                .HasForeignKey(c => c.IdCliente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_cliente");
            
            builder.HasOne(c => c.TipoConta)
                .WithMany(t=> t.Contas)
                .HasForeignKey(c => c.IdTipoConta)            
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_tipo_conta");

            builder.Property(c => c.CnpjVinculado)
            .HasMaxLength(14)
            .IsRequired(false); // Define como opcional no banco

            builder.Property(c => c.LimiteCredito)
                .HasPrecision(18, 2)
                .IsRequired(false);

            builder.Property(c => c.DiaRendimento)
                .IsRequired(false);

            builder.Property(c => c.TaxaJuros)
                .HasPrecision(5, 2) // Ex: 12.50%
                .IsRequired(false);
        }
    }
}
