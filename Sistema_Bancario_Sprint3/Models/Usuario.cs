using Sistema_Bancario_Sprint3.Models.ENUM;

namespace Sistema_Bancario_Sprint3.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;

        public Role Role { get; set; }

        // Status para o fluxo de aprovação: "Pendente", "Ativo", "Bloqueado"
        public StatusUsuario Status { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public long? IdCliente { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
