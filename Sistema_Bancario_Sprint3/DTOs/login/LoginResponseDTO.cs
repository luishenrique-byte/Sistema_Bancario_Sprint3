using Microsoft.AspNetCore.Components.Web;

namespace Sistema_Bancario_Sprint3.DTOs.login
{
    public class LoginResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public bool PrecisaCompletarCadastro { get; set; }
    }
}
