using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Bancario_Sprint3.Data;
using Sistema_Bancario_Sprint3.DTOs;
using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly AppDbContext _context;

        // Injeção de dependência do DbContext
        public ClientesController(AppDbContext context)
        {
            _context = context;
        }
        public interface IActionResult<T>
        {
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null) return NotFound(new {mensagem = "Cliente não encontrado"});

            var clienteDTO = new ClienteResponseDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                TipoPessoa = cliente.TipoPessoa,
                DataCadastro = cliente.DataCadastro
            };

            return Ok(clienteDTO);
        }


        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
        
            var clientes = await _context.Clientes.ToListAsync();

            var clientesDTO = clientes.Select(c => new ClienteResponseDTO
            {

                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Telefone = c.Telefone,
                TipoPessoa = c.TipoPessoa,               
                DataCadastro = c.DataCadastro
            }).ToList();

            return Ok(clientesDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteResponseDTO>> PostCliente(ClienteResquestDTO clienteRequest)
        {
            var novoCliente = new Cliente
            {
                Nome = clienteRequest.Nome,
                Email = clienteRequest.Email,
                Telefone = clienteRequest.Telefone,
                TipoPessoa = clienteRequest.TipoPessoa,
                cpfCnpj = clienteRequest.cpfCnpj
            };

            _context.Clientes.Add(novoCliente);
            await _context.SaveChangesAsync();

            var clienteResponse = new ClienteResponseDTO
            {
                Id = novoCliente.Id,
                Nome = novoCliente.Nome,
                Email = novoCliente.Email,
                Telefone = novoCliente.Telefone,
                TipoPessoa = novoCliente.TipoPessoa,                
                DataCadastro = novoCliente.DataCadastro
            };
            return CreatedAtAction(nameof(GetCliente), new { id = clienteResponse.Id }, clienteResponse);
        }        
    }
}

    