using Sistema_Bancario_Sprint3.DTOs.cliente;
using Sistema_Bancario_Sprint3.Models;
using Sistema_Bancario_Sprint3.Repositories.cliente;

namespace Sistema_Bancario_Sprint3.Services.cliente
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<ClienteResponseDTO>> ObterTodos()
        {
            var clientes = await _repository.GetClientes();
            return clientes.Select(c => new ClienteResponseDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Telefone = c.Telefone,
                TipoPessoa = c.TipoPessoa,
                DataCadastro = c.DataCadastro
            });
        }
        public async Task<ClienteResponseDTO> ObterPorId(long id)
        {
            var cliente = await _repository.GetClienteById(id);
            if (cliente == null)
            {
                return null;
            }
            return new ClienteResponseDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                TipoPessoa = cliente.TipoPessoa,
                DataCadastro = cliente.DataCadastro
            };
        }
        public async Task<ClienteResponseDTO> CriarCliente(ClienteRequestDTO clienteDTO)
        {
            var novoCliente = new Cliente
            {
                Nome = clienteDTO.Nome,
                Email = clienteDTO.Email,
                Telefone = clienteDTO.Telefone,
                TipoPessoa = clienteDTO.TipoPessoa,
                cpfCnpj = clienteDTO.cpfCnpj,
                DataCadastro = DateTime.Now
            };
            await _repository.PostCliente(novoCliente);
            return new ClienteResponseDTO
            {
                Id = novoCliente.Id,
                Nome = novoCliente.Nome,
                Email = novoCliente.Email,
                Telefone = novoCliente.Telefone,
                TipoPessoa = novoCliente.TipoPessoa,
                DataCadastro = novoCliente.DataCadastro
            };
        }

        public async Task DeletarCliente(long id)
        {
            await _repository.DeleteCliente(id);
        }

        public async Task AtualizarCliente(long id,ClienteRequestDTO clienteResquest)
        {
            var clienteExistente= await _repository.GetClienteById(id);

            if (clienteExistente == null)
            {
                throw new Exception("Cliente não encontrado");
            }
            clienteExistente.Nome = clienteResquest.Nome;
            clienteExistente.Email = clienteResquest.Email;
            clienteExistente.Telefone = clienteResquest.Telefone;
            clienteExistente.TipoPessoa = clienteResquest.TipoPessoa;
            clienteExistente.cpfCnpj = clienteResquest.cpfCnpj;
            await _repository.UpdateCliente(clienteExistente);
        }
    }
}
