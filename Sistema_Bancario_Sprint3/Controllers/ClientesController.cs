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
                tipoPessoa = c.tipoPessoa,
                cpfCnpj = c.cpfCnpj,
                DataCadastro = c.DataCadastro
            }).ToList();

            return Ok(clientesDTO);
        }  
        

    }
}

    