using Sistema_Bancario_Sprint3.Models;
using Sistema_Bancario_Sprint3.Data;
using Microsoft.EntityFrameworkCore;

namespace Sistema_Bancario_Sprint3.Repositories.cliente
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        // READ ALL
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }
        // READ ONE (Buscar por ID)
        public async Task<Cliente> GetClienteById(long id)
        {
            return await _context.Clientes.FindAsync(id);
        }
        // CREATE
        public async Task PostCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }
        // UPDATE
        public async Task UpdateCliente(Cliente c)
        {
            _context.Clientes.Update(c);
            await _context.SaveChangesAsync();
        }
        // DELETE
        public async Task DeleteCliente(long id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();                
            }
        }
    }
}