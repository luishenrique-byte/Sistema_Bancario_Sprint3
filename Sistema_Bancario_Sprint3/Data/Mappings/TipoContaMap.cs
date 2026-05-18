using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Data.Mappings
{
    public class TipoContaMap : IEntityTypeConfiguration<TipoConta>
    {
        public void Configure(EntityTypeBuilder<TipoConta> builder)
        {
            builder.ToTable("Tipos_Contas");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Nome)
                .HasMaxLength(50)
                .IsRequired();

            // 👇 CARGA INICIAL (DATA SEEDING)
            // Isso diz ao Entity Framework para injetar esses dados assim que a tabela for criada
            builder.HasData(
                new TipoConta { Id = 1, Nome = "Corrente" },
                new TipoConta { Id = 2, Nome = "Poupança" },
                new TipoConta { Id = 3, Nome = "Empresarial" }
            );
        }
    }
}
