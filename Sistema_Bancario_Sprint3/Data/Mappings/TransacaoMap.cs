using Microsoft.EntityFrameworkCore;
using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Data.Mappings
{
    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacoes");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.DataHora)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            builder.HasOne(t => t.ContaOrigem)
                .WithMany()
                .HasForeignKey(t => t.IdContaOrigem)
                .HasConstraintName("FK_conta_origem")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.ContaDestino)
                .WithMany()
                .HasForeignKey(t => t.IdContaDestino)
                .IsRequired(false)
                .HasConstraintName("FK_conta_destino")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
