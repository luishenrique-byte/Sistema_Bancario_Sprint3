using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Bancario_Sprint3.Models;
using Sistema_Bancario_Sprint3.Models.ENUM;

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

            var dataSeed = new DateTime(2024, 1, 1);
            builder.HasData(
                new Cliente { Id = 20, Nome = "João Silva",        Email = "joao@ubank.com",    Telefone = "(81) 99999-0001", TipoPessoa = TipoPessoa.PF, cpfCnpj = "11111111111",    DataCadastro = dataSeed },
                new Cliente { Id = 21, Nome = "Maria Santos",      Email = "maria@ubank.com",   Telefone = "(81) 99999-0002", TipoPessoa = TipoPessoa.PF, cpfCnpj = "22222222222",    DataCadastro = dataSeed },
                new Cliente { Id = 22, Nome = "Tech Empresa Ltda", Email = "empresa@ubank.com", Telefone = "(81) 99999-0003", TipoPessoa = TipoPessoa.PJ, cpfCnpj = "00000000000100", DataCadastro = dataSeed }
            );
        }
    }
}
