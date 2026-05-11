using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Repositories.transacao
{
    public interface ITransacaoRepository
    {
        Task<IEnumerable<Transacao>> GetTransacoes();
        Task<Transacao> GetTransacaoById(long id);
        Task<IEnumerable<Transacao>> GetTransacoesByConta(long contaId);
        Task PostTransacao(Transacao transacao);
    }
}
