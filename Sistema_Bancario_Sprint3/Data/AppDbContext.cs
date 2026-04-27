using Microsoft.EntityFrameworkCore;
using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }        
        public DbSet<Conta> Contas { get; set; }
        public DbSet<ContaCorrente> Contas_Corrente { get; set; }
        public DbSet<ContaPoupanca> Contas_Poupanca { get; set; }
        public DbSet<ContaEmpresarial> Contas_Empresarial { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
