using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd(); 
            
            builder.Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(100);

            builder.Property(c => c.Telefone)
                .HasMaxLength(20);

            builder.Property(c => c.TipoPessoa)
                .IsRequired();

            builder.Property(c => c.cpfCnpj)
                .IsRequired();

            builder.Property(c => c.DataCadastro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            //comentar
            //builder.HasMany(c => c.Contas)
            //    .WithOne(c => c.Cliente)
            //    .HasForeignKey(c => c.IdCliente)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
