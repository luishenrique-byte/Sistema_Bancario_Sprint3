using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_Bancario_Sprint3.DTOs.transacao;
using Sistema_Bancario_Sprint3.Services.transacao;

namespace Sistema_Bancario_Sprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _service;

        public TransacaoController(ITransacaoService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostTransacao(TransacaoRequestDTO request)
        {            
            try
            {
                var resultado = await _service.RealizarTransacao(request);                
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTransacoes()
        {
            var transacoes = await _service.ObterTodos();
            return Ok(transacoes);
        }

        [HttpGet("extrato/{contaId}")]
        public async Task<IActionResult> GetExtrato(long contaId)
        {
            var extrato = await _service.ObterExtrato(contaId);
            return Ok(extrato);
        }
    }
}
