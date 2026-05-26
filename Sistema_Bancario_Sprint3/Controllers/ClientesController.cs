using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_Bancario_Sprint3.DTOs.cliente;
using Sistema_Bancario_Sprint3.Services.cliente;

namespace Sistema_Bancario_Sprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        // Injeção de dependência do ropository
        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _service.ObterTodos();
            return Ok(clientes);
        }

        [Authorize]
        [HttpGet("buscar-por-chave")]
        public async Task<IActionResult> BuscarPorChave([FromQuery] string chave)
        {
            if (string.IsNullOrWhiteSpace(chave))
                return BadRequest(new { message = "Chave inválida." });

            var cliente = await _service.BuscarPorChave(chave.Trim());
            if (cliente == null)
                return NotFound(new { message = "Nenhuma conta encontrada para esta chave Pix." });

            return Ok(new { id = cliente.Id, nome = cliente.Nome });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(long id)
        {
           var cliente = await _service.ObterPorId(id);
            if (cliente == null)
            {
                return NotFound(new { mensagem = "Cliente não encontrado"});
            }

            return Ok(cliente);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostCliente(ClienteRequestDTO request)
        {
            // 1. O C# abre o Token JWT e pega o E-mail com 100% de segurança
            var emailUsuario = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(emailUsuario))
            {
                return Unauthorized(new { mensagem = "Token inválido ou sem e-mail." });
            }

            // 2. Você injeta o e-mail seguro direto no DTO (mesmo que o front não tenha enviado)
            request.Email = emailUsuario;

            // 3. Continua o fluxo normal para salvar no banco
            var clienteCriado = await _service.CriarCliente(request);
            return CreatedAtAction(nameof(GetCliente), new { id = clienteCriado.Id }, clienteCriado);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(long id, ClienteRequestDTO cliente)
        {
            try
            {
                await _service.AtualizarCliente(id, cliente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(long id)
        {
            try
            {
                await _service.DeletarCliente(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}