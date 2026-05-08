using Sistema_Bancario_Sprint3.DTOs.cliente;
using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Services.cliente
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponseDTO>> ObterTodos();
        Task<ClienteResponseDTO> ObterPorId(long id);
        Task<ClienteResponseDTO> CriarCliente(ClienteRequestDTO clienteResquest);
        Task DeletarCliente(long id);
        Task AtualizarCliente(long id,ClienteRequestDTO clienteRequest);
    }
}
