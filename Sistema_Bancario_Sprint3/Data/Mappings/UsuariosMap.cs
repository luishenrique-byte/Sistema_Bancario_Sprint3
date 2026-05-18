using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Bancario_Sprint3.Models;
using Sistema_Bancario_Sprint3.Models.ENUM;

namespace Sistema_Bancario_Sprint3.Data.Mappings
{
    public class UsuariosMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            // Garante na base de dados que nenhum e-mail de login se repita
            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.SenhaHash)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.Role)
                .HasMaxLength(30)
                .HasDefaultValue(Role.Cliente)
                .IsRequired();

            builder.Property(u => u.Status)
                .HasMaxLength(30)
                .HasDefaultValue(StatusUsuario.Pendente)
                .IsRequired();

            builder.Property(u => u.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            // Mapeia o relacionamento unidirecional com a sua tabela antiga
            builder.HasOne(u => u.Cliente)
                .WithMany() // Fica vazio porque a classe Cliente não conhece a propriedade Usuario
                .HasForeignKey(u => u.IdCliente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Usuario_Cliente");
        }
    }
}
