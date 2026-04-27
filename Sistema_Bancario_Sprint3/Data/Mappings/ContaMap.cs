using Microsoft.EntityFrameworkCore;
using MySqlConnector;
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

            builder.Property(c => c.TipoConta)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(c => c.DataAbertura)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(c => c.Cliente)
                .WithMany(cl => cl.Contas)
                .HasForeignKey(c => c.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
