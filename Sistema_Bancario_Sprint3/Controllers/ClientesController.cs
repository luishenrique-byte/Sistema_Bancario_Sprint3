using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Bancario_Sprint3.Data;
using Sistema_Bancario_Sprint3.DTOs.cliente;
using Sistema_Bancario_Sprint3.Models;
using Sistema_Bancario_Sprint3.Repositories;
using Sistema_Bancario_Sprint3.Services.cliente;

namespace Sistema_Bancario_Sprint3.Controllers
{
    [Route("api/clientes")]
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