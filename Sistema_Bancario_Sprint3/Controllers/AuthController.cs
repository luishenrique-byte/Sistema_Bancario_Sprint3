using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sistema_Bancario_Sprint3.DTOs.login;
using Sistema_Bancario_Sprint3.Services.login;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sistema_Bancario_Sprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        //private readonly IConfiguration _configuration;

        //public AuthController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequestDTO login)
        //{
        //    if (login.Usuario == "admin" && login.Senha == "123456")
        //    {
        //        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new[]
        //            {
        //                    new Claim(ClaimTypes.Name, login.Usuario),
        //                    new Claim(ClaimTypes.Role, "Administrador")
        //                }),
        //            Expires = DateTime.UtcNow.AddHours(2),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        //            Issuer = _configuration["Jwt:Issuer"],
        //            Audience = _configuration["Jwt:Audience"]
        //        };

        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var token = tokenHandler.CreateToken(tokenDescriptor);

        //        return Ok(new
        //        {
        //            token = tokenHandler.WriteToken(token),
        //            mensagem = "Login feito com sucesso"
        //        });

        //    }

        //    return Unauthorized(new
        //    {
        //        erro = "Usuário e/ou Senha inválidos"
        //    });

        //}


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {

            try
            {

                var resultado = await _authService.LoginAsync(request);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return Unauthorized(new { mensagem = ex.Message });
            }
        }
    }
}
