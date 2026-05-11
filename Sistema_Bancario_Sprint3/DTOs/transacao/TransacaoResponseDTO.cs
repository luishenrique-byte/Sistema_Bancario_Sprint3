using Sistema_Bancario_Sprint3.Models.ENUM;

namespace Sistema_Bancario_Sprint3.DTOs.transacao
{
    public class TransacaoResponseDTO
    {
        public long Id { get; set; }
        public TipoTransacao Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
        public long IdContaOrigem { get; set; }
        public long? IdContaDestino { get; set; }
    }
}
