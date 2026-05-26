using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Repositories.cliente
{
    public interface IClienteRepository
    {
        // READ ALL
        Task<IEnumerable<Cliente>> GetClientes();
        // READ ONE (Buscar por ID)
        Task<Cliente> GetClienteById(long id);
        // READ ONE (Buscar por Chave Pix: email, CPF/CNPJ ou telefone)
        Task<Cliente?> GetClienteByChave(string chave);
        // CREATE
        Task PostCliente(Cliente cliente);
        // UPDATE
        Task UpdateCliente(Cliente c);
        // DELETE
        Task DeleteCliente(long id);
    }
}
