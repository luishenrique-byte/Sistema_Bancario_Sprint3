using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Bancario_Sprint3.Data;
using Sistema_Bancario_Sprint3.DTOs;
using Sistema_Bancario_Sprint3.Models;
using Sistema_Bancario_Sprint3.Repositories;

namespace Sistema_Bancario_Sprint3.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        // Injeção de dependência do ropository
        public ClientesController(IClienteRepository repository)
        {
            _repository = repository;
        }




        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _repository.GetClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(long id)
        {
            var cliente = await _repository.GetClienteById(id);
            if (cliente == null)
            {
                return NotFound(new { mensagem = "Cliente não encontrado" });
            }
            return Ok(cliente);
            //[HttpGet("{id}")]
            //public async Task<IActionResult> GetCliente(int id)
            //{

            //    var cliente = await _context.Clientes.FindAsync(id);

            //    if (cliente == null) return NotFound(new { mensagem = "Cliente não encontrado" });
            //    /**
            //     * tem ir dentro do service
            //    var clienteDTO = new ClienteResponseDTO
            //    {
            //        Id = cliente.Id,
            //        Nome = cliente.Nome,
            //        Email = cliente.Email,
            //        Telefone = cliente.Telefone,
            //        TipoPessoa = cliente.TipoPessoa,
            //        DataCadastro = cliente.DataCadastro
            //    };*/

            //    return Ok(clienteDTO);
            //}
        }
        [HttpPost]
        public async Task<IActionResult> PostCliente(Cliente cliente)
        {
            await _repository.PostCliente(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
            //[HttpPost]
            //public async Task<ActionResult<ClienteResponseDTO>> PostCliente(ClienteResquestDTO clienteRequest)
            //{
            //    var novoCliente = new Cliente
            //    {
            //        Nome = clienteRequest.Nome,
            //        Email = clienteRequest.Email,
            //        Telefone = clienteRequest.Telefone,
            //        TipoPessoa = clienteRequest.TipoPessoa,
            //        cpfCnpj = clienteRequest.cpfCnpj
            //    };

            //    _context.Clientes.Add(novoCliente);
            //    await _context.SaveChangesAsync();

            //    var clienteResponse = new ClienteResponseDTO
            //    {
            //        Id = novoCliente.Id,
            //        Nome = novoCliente.Nome,
            //        Email = novoCliente.Email,
            //        Telefone = novoCliente.Telefone,
            //        TipoPessoa = novoCliente.TipoPessoa,                
            //        DataCadastro = novoCliente.DataCadastro
            //    };
            //    return CreatedAtAction(nameof(GetCliente), new { id = clienteResponse.Id }, clienteResponse);
            //}        
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(long id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest(new { mensagem = "ID do cliente não corresponde" });
            }
            var existingCliente = await _repository.GetClienteById(id);
            if (existingCliente == null)
            {
                return NotFound(new { mensagem = "Cliente não encontrado" });
            }
            existingCliente.Nome = cliente.Nome;
            existingCliente.Email = cliente.Email;
            existingCliente.Telefone = cliente.Telefone;
            existingCliente.TipoPessoa = cliente.TipoPessoa;
            existingCliente.cpfCnpj = cliente.cpfCnpj;
            await _repository.UpdateCliente(existingCliente);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(long id)
        {
            var existingCliente = await _repository.GetClienteById(id);
            if (existingCliente == null)
            {
                return NotFound(new { mensagem = "Cliente não encontrado" });
            }
            await _repository.DeleteCliente(id);
            return NoContent();
        }
    }
}