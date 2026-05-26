using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_Bancario_Sprint3.DTOs.conta;
using Sistema_Bancario_Sprint3.Repositories.usuario;
using Sistema_Bancario_Sprint3.Services.conta;

namespace Sistema_Bancario_Sprint3.Controllers
{
    [Route("api/contas")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContaService _service;
        private readonly IUsuarioRepository _usuarioRepository;

        public ContasController(IContaService service, IUsuarioRepository usuarioRepository)
        {
            _service = service;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetContas()
        {
            var contas = await _service.ObterTodas();
            return Ok(contas);
        }

        [Authorize]
        [HttpGet("minhas-contas")]
        public async Task<IActionResult> GetMinhasContas()
        {
            var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
                return Unauthorized(new { message = "Token inválido." });

            var usuario = await _usuarioRepository.GetByEmailAsync(email);
            if (usuario == null || usuario.IdCliente == null)
                return Ok(new List<object>());

            var contas = await _service.ObterPorCliente(usuario.IdCliente.Value);
            return Ok(contas);
        }

        [Authorize]
        [HttpGet("por-cliente/{clienteId}")]
        public async Task<IActionResult> GetContasByCliente(long clienteId)
        {
            var contas = await _service.ObterPorCliente(clienteId);
            return Ok(contas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContaById(long id)
        {
            var conta = await _service.ObterPorId(id);
            if (conta == null)
            {
                return NotFound(new { message = "Conta não encontrada." });
            }
            return Ok(conta);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostConta(ContaRequestDTO request)
        {
            try
            {
                var novaConta = await _service.CriarConta(request);
                return CreatedAtAction(nameof(GetContaById), new { id = novaConta.Id }, novaConta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCLiente(long id, ContaRequestDTO request)
        {
            await _service.AtualizarConta(id, request);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConta(long id)
        {
            try
            {
                await _service.DeletarConta(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
