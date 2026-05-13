using Sistema_Bancario_Sprint3.DTOs.transacao;
using Sistema_Bancario_Sprint3.Models;
using Sistema_Bancario_Sprint3.Models.ENUM;
using Sistema_Bancario_Sprint3.Repositories.conta;
using Sistema_Bancario_Sprint3.Repositories.transacao;

namespace Sistema_Bancario_Sprint3.Services.transacao
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepo;
        private readonly IContaRepository _contaRepo;

        public TransacaoService(ITransacaoRepository trasacaoRepo, IContaRepository contaRepo)
        {
            _transacaoRepo = trasacaoRepo;
            _contaRepo = contaRepo;
        }

        public async Task<IEnumerable<TransacaoResponseDTO>> ObterTodos()
        {
            var transacoes = await _transacaoRepo.GetTransacoes();
            return transacoes.Select(t => new TransacaoResponseDTO
            {
                Id = t.Id,
                Tipo = t.Tipo,
                Valor = t.Valor,
                DataHora = t.DataHora,
                IdContaOrigem = t.IdContaOrigem,
                IdContaDestino = t.IdContaDestino                
            });
        }
        public async Task<IEnumerable<TransacaoResponseDTO>> ObterExtrato(long contaId)
        {
            var transacoes = await _transacaoRepo.GetTransacoesByConta(contaId);
            return transacoes.Select(t => new TransacaoResponseDTO
            {
                Id = t.Id,
                Tipo = t.Tipo,
                Valor = t.Valor,
                DataHora = t.DataHora,
                IdContaOrigem = t.IdContaOrigem,
                IdContaDestino = t.IdContaDestino                
            });
        }

        public async Task<TransacaoResponseDTO> RealizarTransacao(TransacaoRequestDTO request)
        {           
            var contaOrigem = await _contaRepo.GetContaById(request.IdContaOrigem);
            if (contaOrigem == null) throw new Exception("Conta de Origem não encontrada.");


            // 1. Lógica de Saldo baseada no tipo
            if (request.Tipo == TipoTransacao.Saque || request.Tipo == TipoTransacao.Tranferencia)
            {
                
                if (contaOrigem.Saldo < request.Valor) throw new Exception("Saldo insuficiente para realizar a operação.");

                contaOrigem.Saldo -= request.Valor;

            } else if(request.Tipo == TipoTransacao.Deposito)
            {

                contaOrigem.Saldo += request.Valor;

            }

            // 2. Lógica específica para Transferência
            if (request.Tipo == TipoTransacao.Tranferencia)
            {

                if (request.IdContaDestino == null) throw new Exception("Conta de Destino é obrigatória para transferências");

                var contaDestino = await _contaRepo.GetContaById(request.IdContaDestino.Value);
                if (contaDestino == null) throw new Exception("Conta de destino não encontrada.");

                contaDestino.Saldo += request.Valor;
                await _contaRepo.UpdateConta(contaDestino);
            }

            // 3. Persistir alteração de saldo na conta de origem
            await _contaRepo.UpdateConta(contaOrigem);

            // 4. Registrar a transação
            var novaTransacao = new Transacao
            {
                Tipo = request.Tipo,
                Valor = request.Valor,
                DataHora = DateTime.Now,
                IdContaOrigem = request.IdContaOrigem,
                IdContaDestino = request.IdContaDestino,               
            };

            await _transacaoRepo.PostTransacao(novaTransacao);
            
            return new TransacaoResponseDTO
            {
                Id = novaTransacao.Id,
                Tipo = novaTransacao.Tipo,
                Valor = novaTransacao.Valor,
                DataHora = novaTransacao.DataHora,
                IdContaOrigem = novaTransacao.IdContaOrigem,
                IdContaDestino = novaTransacao.IdContaDestino,                
            };

        }
    }
}
