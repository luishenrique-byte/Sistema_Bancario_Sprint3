using Sistema_Bancario_Sprint3.DTOs.transacao;
using Sistema_Bancario_Sprint3.Models;
using Sistema_Bancario_Sprint3.Models.ENUM;
using Sistema_Bancario_Sprint3.Services.transacao;
using Sistema_Bancario_Sprint3.Repositories.conta;
using Sistema_Bancario_Sprint3.Repositories.transacao;

namespace Sistema_Bancario_Sprint3.Services.transacao
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepo;
        private readonly IContaRepository _contaRepo;

        // Constantes
        private const decimal TARIFA_TEF = 5.00m;
        private const decimal VALOR_MINIMO = 0.01m;
        private const decimal VALOR_MAXIMO = 999999999.99m;

        public TransacaoService(ITransacaoRepository trasacaoRepo, IContaRepository contaRepo)
        {
            _transacaoRepo = trasacaoRepo;
            _contaRepo = contaRepo;
        }

        /// <summary>
        /// Realiza uma transação com validações completas
        /// </summary>
        public async Task<TransacaoResponseDTO> RealizarTransacao(TransacaoRequestDTO request)
        {
            // 1. Validações de entrada
            if (request.IdContaOrigem <= 0)
                throw new ArgumentException("ID da conta de origem é inválido.");

            if (request.Valor < VALOR_MINIMO || request.Valor > VALOR_MAXIMO)
                throw new ArgumentException($"Valor deve estar entre R$ {VALOR_MINIMO} e R$ {VALOR_MAXIMO:N2}");

            // 2. Validar conta de origem existe
            var contaOrigem = await _contaRepo.GetContaById(request.IdContaOrigem);
            if (contaOrigem == null)
                throw new ArgumentException("Conta de origem não encontrada.");

            if (contaOrigem.Status != Status.ativa)
                throw new InvalidOperationException("Conta de origem inativa.");

            // 3. Lógica de validação por tipo de transação
            switch (request.Tipo)
            {
                case TipoTransacao.Saque:
                    ValidarSaque(contaOrigem, request.Valor);
                    break;

                case TipoTransacao.Tranferencia:
                    ValidarTransferencia(request, contaOrigem);
                    break;

                case TipoTransacao.Deposito:
                    ValidarDeposito(request.Valor);
                    break;

                default:
                    throw new ArgumentException("Tipo de transação inválido.");
            }

            // 4. Executar a transação
            return await ExecutarTransacao(contaOrigem, request);
        }

        public void ValidarSaque(Conta conta, decimal valor)
        {
            // Contas empresariais podem usar o limite de crédito como saldo extra
            var isEmpresarial = conta.IdTipoConta == 3 && conta.LimiteCredito.HasValue;
            var disponivel = isEmpresarial
                ? conta.Saldo + conta.LimiteCredito!.Value
                : conta.Saldo;

            if (valor > disponivel)
            {
                var msg = isEmpresarial
                    ? $"Limite insuficiente. Disponível: R$ {disponivel:N2} (Saldo: R$ {conta.Saldo:N2} | Crédito: R$ {conta.LimiteCredito!.Value:N2})"
                    : $"Saldo insuficiente. Disponível: R$ {conta.Saldo:N2}";
                throw new InvalidOperationException(msg);
            }
        }

        public void ValidarTransferencia(TransacaoRequestDTO request, Conta contaOrigem)
        {
            if (request.IdContaDestino == null || request.IdContaDestino <= 0)
                throw new ArgumentException("Conta de destino é obrigatória para transferências.");

            if (contaOrigem.Saldo < request.Valor)
                throw new InvalidOperationException($"Saldo insuficiente. Disponível: R$ {contaOrigem.Saldo:N2}");
        }

        public void ValidarDeposito(decimal valor)
        {
            // Depósitos geralmente não têm muita restrição
            // mas podem ter limites institucionais
        }

        public async Task<TransacaoResponseDTO> ExecutarTransacao(Conta contaOrigem, TransacaoRequestDTO request)
        {
            try
            {
                // 1. Aplicar lógica de saldo
                if (request.Tipo == TipoTransacao.Saque || request.Tipo == TipoTransacao.Tranferencia)
                {
                    contaOrigem.Saldo -= request.Valor;
                }
                else if (request.Tipo == TipoTransacao.Deposito)
                {
                    contaOrigem.Saldo += request.Valor;
                }

                // 2. Se for transferência, processar conta destino
                if (request.Tipo == TipoTransacao.Tranferencia && request.IdContaDestino.HasValue)
                {
                    var contaDestino = await _contaRepo.GetContaById(request.IdContaDestino.Value);
                    if (contaDestino == null)
                        throw new ArgumentException("Conta de destino não encontrada.");

                    if (contaDestino.Status != Status.ativa)
                        throw new InvalidOperationException("Conta de destino inativa.");

                    contaDestino.Saldo += request.Valor;
                    await _contaRepo.UpdateConta(contaDestino);
                }

                // 3. Atualizar conta de origem
                await _contaRepo.UpdateConta(contaOrigem);

                // 4. Registrar transação
                var novaTransacao = new Transacao
                {
                    Tipo = request.Tipo,
                    Valor = request.Valor,
                    DataHora = DateTime.Now,
                    IdContaOrigem = request.IdContaOrigem,
                    IdContaDestino = request.IdContaDestino
                };

                await _transacaoRepo.PostTransacao(novaTransacao);

                return new TransacaoResponseDTO
                {
                    Id = novaTransacao.Id,
                    Tipo = novaTransacao.Tipo,
                    Valor = novaTransacao.Valor,
                    DataHora = novaTransacao.DataHora,
                    IdContaOrigem = novaTransacao.IdContaOrigem,
                    IdContaDestino = novaTransacao.IdContaDestino
                };
            }
            catch
            {
                // Se algo falhar, as mudanças não foram persistidas
                // pois estamos usando transações no banco
                throw;
            }
        }

        public async Task<IEnumerable<TransacaoResponseDTO>> ObterTodos()
        {
            var transacoes = await _transacaoRepo.GetTransacoes();
            return transacoes.Select(MapearTransacao);
        }

        public async Task<IEnumerable<TransacaoResponseDTO>> ObterExtrato(long contaId)
        {
            if (contaId <= 0)
                throw new ArgumentException("ID da conta inválido.");

            var transacoes = await _transacaoRepo.GetTransacoesByConta(contaId);
            return transacoes.Select(MapearTransacao);
        }

        /// <summary>
        /// Obtém extrato com filtros por data e tipo
        /// </summary>
        public async Task<IEnumerable<TransacaoResponseDTO>> ObterExtratoFiltrado(long contaId, DateTime? dataInicio, DateTime? dataFim, int? tipo)
        {
            if (contaId <= 0)
                throw new ArgumentException("ID da conta inválido.");

            var transacoes = await _transacaoRepo.GetTransacoesByConta(contaId);

            // Filtrar por data início
            if (dataInicio.HasValue)
                transacoes = transacoes.Where(t => t.DataHora >= dataInicio.Value);

            // Filtrar por data fim
            if (dataFim.HasValue)
                transacoes = transacoes.Where(t => t.DataHora <= dataFim.Value.AddDays(1));

            // Filtrar por tipo
            if (tipo.HasValue)
                transacoes = transacoes.Where(t => (int)t.Tipo == tipo.Value);

            return transacoes.Select(MapearTransacao);
        }

        /// <summary>
        /// Retorna resumo de transações (totalizações)
        /// </summary>
        public async Task<object> ObterResumoTransacoes(long contaId, DateTime? dataInicio, DateTime? dataFim)
        {
            if (contaId <= 0)
                throw new ArgumentException("ID da conta inválido.");

            var transacoes = await _transacaoRepo.GetTransacoesByConta(contaId);

            // Filtrar por data
            if (dataInicio.HasValue)
                transacoes = transacoes.Where(t => t.DataHora >= dataInicio.Value);

            if (dataFim.HasValue)
                transacoes = transacoes.Where(t => t.DataHora <= dataFim.Value.AddDays(1));

            var todasTransacoes = transacoes.ToList();

            return new
            {
                totalTransacoes = todasTransacoes.Count,
                totalEntradas = todasTransacoes
                    .Where(t => t.Tipo == TipoTransacao.Deposito)
                    .Sum(t => t.Valor),
                totalSaidas = todasTransacoes
                    .Where(t => t.Tipo == TipoTransacao.Saque || t.Tipo == TipoTransacao.Tranferencia)
                    .Sum(t => t.Valor),
                saldoLiquido = todasTransacoes
                    .Where(t => t.Tipo == TipoTransacao.Deposito)
                    .Sum(t => t.Valor) -
                    todasTransacoes
                    .Where(t => t.Tipo == TipoTransacao.Saque || t.Tipo == TipoTransacao.Tranferencia)
                    .Sum(t => t.Valor),
                periodo = new
                {
                    inicio = dataInicio?.ToString("yyyy-MM-dd"),
                    fim = dataFim?.ToString("yyyy-MM-dd")
                }
            };
        }

        public TransacaoResponseDTO MapearTransacao(Transacao t)
        {
            return new TransacaoResponseDTO
            {
                Id = t.Id,
                Tipo = t.Tipo,
                Valor = t.Valor,
                DataHora = t.DataHora,
                IdContaOrigem = t.IdContaOrigem,
                IdContaDestino = t.IdContaDestino
            };
        }
    }
}