using Sistema_Bancario_Sprint3.DTOs.login;
using Sistema_Bancario_Sprint3.Models.ENUM;

namespace Sistema_Bancario_Sprint3.Services.login
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequest);
        Task RegistrarAsync(string email, string senha);
        string GerarTokenJwt(string email, string role);
    }
}
