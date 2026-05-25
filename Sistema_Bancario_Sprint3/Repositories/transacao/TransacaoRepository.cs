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

        /// <summary>
        /// Obtém todas as transações, ordenadas por data decrescente
        /// </summary>
        public async Task<IEnumerable<Transacao>> GetTransacoes()
        {
            return await _context.Transacoes
                .OrderByDescending(t => t.DataHora)
                .ToListAsync();
        }

        /// <summary>
        /// Obtém uma transação específica pelo ID
        /// </summary>
        public async Task<Transacao> GetTransacaoById(long id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.");

            return await _context.Transacoes.FindAsync(id);
        }

        /// <summary>
        /// Obtém todas as transações de uma conta (entrada e saída)
        /// </summary>
        public async Task<IEnumerable<Transacao>> GetTransacoesByConta(long contaId)
        {
            if (contaId <= 0)
                throw new ArgumentException("ID da conta inválido.");

            return await _context.Transacoes
                .Where(t => t.IdContaOrigem == contaId || t.IdContaDestino == contaId)
                .OrderByDescending(t => t.DataHora)
                .ToListAsync();
        }

        /// <summary>
        /// Obtém transações como origem (saídas)
        /// </summary>
        public async Task<IEnumerable<Transacao>> GetTransacoesPorOrigem(long contaId)
        {
            if (contaId <= 0)
                throw new ArgumentException("ID da conta inválido.");

            return await _context.Transacoes
                .Where(t => t.IdContaOrigem == contaId)
                .OrderByDescending(t => t.DataHora)
                .ToListAsync();
        }

        /// <summary>
        /// Obtém transações como destino (entradas)
        /// </summary>
        public async Task<IEnumerable<Transacao>> GetTransacoesPorDestino(long contaId)
        {
            if (contaId <= 0)
                throw new ArgumentException("ID da conta inválido.");

            return await _context.Transacoes
                .Where(t => t.IdContaDestino == contaId)
                .OrderByDescending(t => t.DataHora)
                .ToListAsync();
        }

        /// <summary>
        /// Obtém transações filtradas por período
        /// </summary>
        public async Task<IEnumerable<Transacao>> GetTransacoesPorPeriodo(long contaId, DateTime dataInicio, DateTime dataFim)
        {
            if (contaId <= 0)
                throw new ArgumentException("ID da conta inválido.");

            return await _context.Transacoes
                .Where(t => (t.IdContaOrigem == contaId || t.IdContaDestino == contaId)
                    && t.DataHora >= dataInicio
                    && t.DataHora <= dataFim.AddDays(1))
                .OrderByDescending(t => t.DataHora)
                .ToListAsync();
        }

        /// <summary>
        /// Registra uma nova transação no banco
        /// </summary>
        public async Task PostTransacao(Transacao transacao)
        {
            if (transacao == null)
                throw new ArgumentNullException(nameof(transacao));

            if (transacao.Valor <= 0)
                throw new ArgumentException("Valor deve ser maior que zero.");

            transacao.DataHora = DateTime.Now;
            await _context.Transacoes.AddAsync(transacao);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Obtém o saldo de uma conta em um período específico
        /// </summary>
        public async Task<decimal> ObterSaldoEmData(long contaId, DateTime data)
        {
            if (contaId <= 0)
                throw new ArgumentException("ID da conta inválido.");

            var saidoAte = await _context.Transacoes
                .Where(t => t.IdContaOrigem == contaId && t.DataHora <= data)
                .SumAsync(t => t.Valor);

            var entradaAte = await _context.Transacoes
                .Where(t => t.IdContaDestino == contaId && t.DataHora <= data)
                .SumAsync(t => t.Valor);

            return entradaAte - saidoAte;
        }
    }
}