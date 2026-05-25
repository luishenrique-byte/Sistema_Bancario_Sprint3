using Microsoft.IdentityModel.Tokens;
using Sistema_Bancario_Sprint3.DTOs.login;
using Sistema_Bancario_Sprint3.Repositories.usuario;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Sistema_Bancario_Sprint3.Models.ENUM;

namespace Sistema_Bancario_Sprint3.Services.login
{
    public class AuthService : IAuthService
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request)
        {
            // 1. Busca o usuário pelo e-mail (enviado no campo 'Usuario' do front)
            var usuario = await _usuarioRepository.GetByEmailAsync(request.Usuario);

            // 2. Se não achar ou se a senha estiver incorreta
            // (Substitua por BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash) quando usar hash real)
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
            {
                throw new Exception("Credenciais inválidas");
            }

            // 3. Gerar o Token JWT
            var token = GerarTokenJwt(usuario.Email, usuario.Role.ToString());

            return new LoginResponseDTO
            {
                Token = token,
                Mensagem = "Login bem-sucedido!",
                PrecisaCompletarCadastro = usuario.IdCliente == null
            };
        }

        public string GerarTokenJwt(string email, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Pega a chave secreta definida no seu appsettings.json
            var chaveSecret = _configuration["Jwt:Key"] ?? "ChaveSuperSecretaEComPeloMenos16Caracteres";
            var key = Encoding.ASCII.GetBytes(chaveSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token válido por 1 hora
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task RegistrarAsync(string email, string senha)
        {
            // Verificar se o usuário já existe
            var usuarioExistente = await _usuarioRepository.GetByEmailAsync(email);
            if (usuarioExistente != null)
            {
                throw new Exception("Usuário já existe");
            }
            // Criar um novo usuário
            var novoUsuario = new Models.Usuario
            {
                Email = email,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(senha) // Substitua por BCrypt.Net.BCrypt.HashPassword(senha) para hash real
            };
            await _usuarioRepository.AddAsync(novoUsuario);
        }
    }
}
