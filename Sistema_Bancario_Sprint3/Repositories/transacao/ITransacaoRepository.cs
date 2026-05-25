using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Repositories.transacao
{
    public interface ITransacaoRepository
    {
        Task<IEnumerable<Transacao>> GetTransacoes();
        Task<Transacao> GetTransacaoById(long id);
        Task<IEnumerable<Transacao>> GetTransacoesByConta(long contaId);
        Task<IEnumerable<Transacao>> GetTransacoesPorOrigem(long contaId);
        Task<IEnumerable<Transacao>> GetTransacoesPorDestino(long contaId);
        Task<IEnumerable<Transacao>> GetTransacoesPorPeriodo(long contaId, DateTime dataInicio, DateTime dataFim);
        Task PostTransacao(Transacao transacao);
        Task<decimal> ObterSaldoEmData(long contaId, DateTime data);
    }
}
