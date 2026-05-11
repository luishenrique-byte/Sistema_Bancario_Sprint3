using Sistema_Bancario_Sprint3.Models.ENUM;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Bancario_Sprint3.DTOs.transacao
{
    public class TransacaoRequestDTO
    {
        [Required]
        public TipoTransacao Tipo {  get; set; }
        public decimal Valor { get; set; }
        public long IdContaOrigem { get; set; }
        public long? IdContaDestino { get; set; }        
    }
}
