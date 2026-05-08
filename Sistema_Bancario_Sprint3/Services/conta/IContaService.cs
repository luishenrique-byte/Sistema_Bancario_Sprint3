using Sistema_Bancario_Sprint3.DTOs.conta;

namespace Sistema_Bancario_Sprint3.Services.conta
{
    public interface IContaService
    {
        Task<IEnumerable<ContaResponseDTO>> ObterTodas();
        Task<ContaResponseDTO> ObterPorId(long id);
        Task<ContaResponseDTO> CriarConta(ContaRequestDTO contaRequest);
        Task<ContaResponseDTO> AtualizarConta(long id, ContaRequestDTO contaRequest);
        Task<bool> DeletarConta(long id);
    }
}
