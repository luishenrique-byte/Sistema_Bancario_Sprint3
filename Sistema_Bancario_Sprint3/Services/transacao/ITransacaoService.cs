using Sistema_Bancario_Sprint3.DTOs.transacao;

namespace Sistema_Bancario_Sprint3.Services.transacao
{
    public interface ITransacaoService
    {
        Task<TransacaoResponseDTO> RealizarTransacao(TransacaoRequestDTO request);
        Task<IEnumerable<TransacaoResponseDTO>> ObterTodos();
        Task<IEnumerable<TransacaoResponseDTO>> ObterExtrato(long contaId);
    }
}
