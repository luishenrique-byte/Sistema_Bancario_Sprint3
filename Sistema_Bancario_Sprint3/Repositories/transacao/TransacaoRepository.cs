using Microsoft.EntityFrameworkCore;
using Sistema_Bancario_Sprint3.Data;
using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Repositories.transacao
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly AppDbContext _context;

        public TransacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transacao>> GetTransacoes()
        {
            return await _context.Transacoes.ToListAsync();
        }

        public async Task<Transacao> GetTransacaoById(long id)
        {
            return await _context.Transacoes.FindAsync(id);
        }

        public async Task<IEnumerable<Transacao>> GetTransacoesByConta(long contaId)
        {
            return await _context.Transacoes
                .Where(t => t.IdContaOrigem == contaId)
                .OrderByDescending(t=>t.DataHora)
                .ToListAsync();
        }

        public async Task PostTransacao(Transacao transacao)
        {
            await _context.Transacoes.AddAsync(transacao);
            await _context.SaveChangesAsync();
        }


    }
}
