using Sistema_Bancario_Sprint3.DTOs.transacao;
using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Services.transacao
{
    public interface ITransacaoService
    {
        Task<TransacaoResponseDTO> RealizarTransacao(TransacaoRequestDTO request);
        void ValidarSaque(Conta conta, decimal valor);
        void ValidarTransferencia(TransacaoRequestDTO request, Conta contaOrigem);
        void ValidarDeposito(decimal valor);
        Task<TransacaoResponseDTO> ExecutarTransacao(Conta contaOrigem, TransacaoRequestDTO request);
        Task<IEnumerable<TransacaoResponseDTO>> ObterTodos();
        Task<IEnumerable<TransacaoResponseDTO>> ObterExtrato(long contaId);
        Task<IEnumerable<TransacaoResponseDTO>> ObterExtratoFiltrado(long contaId, DateTime? dataInicio, DateTime? dataFim, int? tipo);
        Task<object> ObterResumoTransacoes(long contaId, DateTime? dataInicio, DateTime? dataFim);
        TransacaoResponseDTO MapearTransacao(Transacao t);
    }
}
