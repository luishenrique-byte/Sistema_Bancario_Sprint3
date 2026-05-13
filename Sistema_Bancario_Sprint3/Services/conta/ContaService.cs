using Sistema_Bancario_Sprint3.DTOs.conta;
using Sistema_Bancario_Sprint3.Repositories.conta;

namespace Sistema_Bancario_Sprint3.Services.conta
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repository;

        public ContaService(IContaRepository repository)
        {
            _repository = repository;
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

        public async Task<ContaResponseDTO> CriarConta(ContaRequestDTO contaDTO)
        {
            var novaConta = new Models.Conta
            {
                NumeroConta = contaDTO.NumeroConta,
                Agencia = contaDTO.Agencia,
                Status = contaDTO.Status,
                DataAbertura = DateTime.Now,
                IdCliente = contaDTO.IdCliente,
                IdTipoConta = contaDTO.IdTipoConta,
                CnpjVinculado = contaDTO.CnpjVinculado,
                LimiteCredito = contaDTO.LimiteCredito,
                DiaRendimento = contaDTO.DiaRendimento,
                TaxaJuros = contaDTO.TaxaJuros,
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
                contaExistente.Status = request.Status;
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
