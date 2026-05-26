using Sistema_Bancario_Sprint3.Models.ENUM;

namespace Sistema_Bancario_Sprint3.DTOs.conta
{
    public class ContaRequestDTO
    {
        // NumeroConta e Agencia são gerados automaticamente no servidor (ignorados na criação)
        public string? NumeroConta { get; set; }
        public string? Agencia { get; set; }
        public Status? Status { get; set; }
        public long IdCliente { get; set; }
        public long IdTipoConta { get; set; }
        public string? CnpjVinculado { get; set; }
        public decimal? LimiteCredito { get; set; }
        public int? DiaRendimento { get; set; }
        public decimal? TaxaJuros { get; set; }
    }
}
