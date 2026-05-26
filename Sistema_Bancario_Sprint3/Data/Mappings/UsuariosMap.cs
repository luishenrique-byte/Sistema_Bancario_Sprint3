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

            // Senha de todos os seeds: Senha@123
            var dataSeed = new DateTime(2024, 1, 1);
            builder.HasData(
                new Usuario { Id = 20, Email = "joao@ubank.com",    SenhaHash = "$2a$11$CS9lAe5X2fX61LBmblHaBOr13EN/CoeL8XnOzV.Fktv4goiPk3TOW", Role = Role.Cliente, Status = StatusUsuario.Ativo, DataCriacao = dataSeed, IdCliente = 20 },
                new Usuario { Id = 21, Email = "maria@ubank.com",   SenhaHash = "$2a$11$A0vx5bNNOPW3prMi1z0gku//A8214tcA2r2gAU2DSYV2wD4HeowgG", Role = Role.Cliente, Status = StatusUsuario.Ativo, DataCriacao = dataSeed, IdCliente = 21 },
                new Usuario { Id = 22, Email = "empresa@ubank.com", SenhaHash = "$2a$11$mBvpGArj5rA1GE3n01y7quAvjIn1mvngvqUtKRrUVGOiUEjJlcja2", Role = Role.Cliente, Status = StatusUsuario.Ativo, DataCriacao = dataSeed, IdCliente = 22 }
            );
        }
    }
}
