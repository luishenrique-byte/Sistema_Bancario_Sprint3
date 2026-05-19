using Sistema_Bancario_Sprint3.DTOs.login;

namespace Sistema_Bancario_Sprint3.Services.login
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequest);
    }
}
