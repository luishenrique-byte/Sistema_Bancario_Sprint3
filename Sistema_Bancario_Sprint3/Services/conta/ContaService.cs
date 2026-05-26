using Sistema_Bancario_Sprint3.DTOs.conta;
using Sistema_Bancario_Sprint3.Models.ENUM;
using Sistema_Bancario_Sprint3.Repositories.cliente;
using Sistema_Bancario_Sprint3.Repositories.conta;

namespace Sistema_Bancario_Sprint3.Services.conta
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repository;
        private readonly IClienteRepository _clienteRepository;

        private const long ID_TIPO_POUPANCA = 2;
        private const long ID_TIPO_EMPRESARIAL = 3;
        private const decimal TAXA_JUROS_POUPANCA = 0.5m; // 0,5% ao mês (padrão poupança BR)
        private const decimal LIMITE_CREDITO_PJ = 50_000.00m;

        public ContaService(IContaRepository repository, IClienteRepository clienteRepository)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ContaResponseDTO>> ObterTodas()
        {
            var contas = await _repository.GetContas();
            return contas.Select(c => new ContaResponseDTO
            {
                Id = c.Id,
                NumeroConta = c.NumeroConta,
                Agencia = c.Agencia,
                Saldo = c.Saldo,
                Status = c.Status,
                IdCliente = c.IdCliente,
                IdTipoConta = c.IdTipoConta,
                CnpjVinculado = c.CnpjVinculado,
                LimiteCredito = c.LimiteCredito,
                DiaRendimento = c.DiaRendimento,
                TaxaJuros = c.TaxaJuros
            }).ToList();
        }

        public async Task<ContaResponseDTO> ObterPorId(long id)
        {
            var conta = await _repository.GetContaById(id);
            if (conta == null)
            {
                return null;
            }
            return new ContaResponseDTO
            {
                Id = conta.Id,
                NumeroConta = conta.NumeroConta,
                Saldo = conta.Saldo,
                Agencia = conta.Agencia,
                Status = conta.Status,
                IdCliente = conta.IdCliente,
                IdTipoConta = conta.IdTipoConta,
                CnpjVinculado = conta.CnpjVinculado,
                LimiteCredito = conta.LimiteCredito,
                DiaRendimento = conta.DiaRendimento,
                TaxaJuros = conta.TaxaJuros
            };
        }

        public async Task<IEnumerable<ContaResponseDTO>> ObterPorCliente(long clienteId)
        {
            var contas = await _repository.GetContasByClienteId(clienteId);
            return contas.Select(c => new ContaResponseDTO
            {
                Id = c.Id,
                NumeroConta = c.NumeroConta,
                Agencia = c.Agencia,
                Saldo = c.Saldo,
                Status = c.Status,
                IdCliente = c.IdCliente,
                IdTipoConta = c.IdTipoConta,
                CnpjVinculado = c.CnpjVinculado,
                LimiteCredito = c.LimiteCredito,
                DiaRendimento = c.DiaRendimento,
                TaxaJuros = c.TaxaJuros
            }).ToList();
        }

        public async Task<ContaResponseDTO> CriarConta(ContaRequestDTO contaDTO)
        {
            var numeroConta = new Random().Next(1000, 9999).ToString();

            string? cnpjVinculado = null;
            decimal? limiteCredito = contaDTO.LimiteCredito;
            int? diaRendimento = contaDTO.DiaRendimento;
            decimal? taxaJuros = contaDTO.TaxaJuros;

            if (contaDTO.IdTipoConta == ID_TIPO_POUPANCA)
            {
                // Dia de rendimento = dia de abertura da conta (padrão BR)
                diaRendimento ??= DateTime.Now.Day;
                taxaJuros ??= TAXA_JUROS_POUPANCA;
            }

            if (contaDTO.IdTipoConta == ID_TIPO_EMPRESARIAL)
            {
                var cliente = await _clienteRepository.GetClienteById(contaDTO.IdCliente);
                if (cliente != null)
                    cnpjVinculado = cliente.cpfCnpj;

                limiteCredito ??= LIMITE_CREDITO_PJ;
            }

            var novaConta = new Models.Conta
            {
                NumeroConta = numeroConta,
                Agencia = "0001",
                Status = Status.ativa,
                DataAbertura = DateTime.Now,
                IdCliente = contaDTO.IdCliente,
                IdTipoConta = contaDTO.IdTipoConta,
                CnpjVinculado = cnpjVinculado,
                LimiteCredito = limiteCredito,
                DiaRendimento = diaRendimento,
                TaxaJuros = taxaJuros,
                Saldo = 0
            };
            await _repository.PostConta(novaConta);
            return new ContaResponseDTO
            {
                Id = novaConta.Id,
                NumeroConta = novaConta.NumeroConta,
                Agencia = novaConta.Agencia,
                Status = novaConta.Status,
                IdCliente = novaConta.IdCliente,
                IdTipoConta = novaConta.IdTipoConta,
                CnpjVinculado = novaConta.CnpjVinculado,
                LimiteCredito = novaConta.LimiteCredito,
                DiaRendimento = novaConta.DiaRendimento,
                TaxaJuros = novaConta.TaxaJuros
            };
        }

        public async Task AtualizarConta(long id, ContaRequestDTO request)
        {
            var contaExistente = await _repository.GetContaById(id);
            if (contaExistente != null)
            {
                contaExistente.NumeroConta = request.NumeroConta;
                contaExistente.Agencia = request.Agencia;
                if (request.Status.HasValue)
                    contaExistente.Status = request.Status.Value;
                contaExistente.IdCliente = request.IdCliente;
                contaExistente.IdTipoConta = request.IdTipoConta;
                contaExistente.CnpjVinculado = request.CnpjVinculado;
                contaExistente.LimiteCredito = request.LimiteCredito;
                contaExistente.DiaRendimento = request.DiaRendimento;
                contaExistente.TaxaJuros = request.TaxaJuros;
                await _repository.UpdateConta(contaExistente);
            }
        }

        public async Task DeletarConta(long id)
        {
            var contaExistente = await _repository.GetContaById(id);
            if (contaExistente != null) throw new Exception("Conta não encontrada.");

            // Regra de Negócio: Não pode deletar conta com saldo positivo ou devedora!
            if (contaExistente.Saldo != 0)
                throw new Exception("Não é possível encerrar uma conta que possui saldo ou dívida.");

            await _repository.DeleteConta(id);
        }
    }
}
