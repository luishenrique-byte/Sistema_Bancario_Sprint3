using Microsoft.AspNetCore.Mvc;
using Sistema_Bancario_Sprint3.DTOs.conta;
using Sistema_Bancario_Sprint3.Services.conta;

namespace Sistema_Bancario_Sprint3.Controllers
{
    [Route("api/contas")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContaService _service;

        public ContasController(IContaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetContas()
        {
            var contas = await _service.ObterTodas();
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

        [HttpPost]
        public async Task<IActionResult> PostCliente(ContaRequestDTO request)
        {
            var novaConta = await _service.CriarConta(request);
            return CreatedAtAction(nameof(GetContaById), new { id = novaConta.Id }, novaConta);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCLiente(long id, ContaRequestDTO request)
        {
            await _service.AtualizarConta(id, request);
            return NoContent();
        }

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
