namespace Sistema_Bancario_Sprint3.Models
{
    public class Transacao
    {
        public long Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;
        public long IdContaOrigem { get; set; }
        public Conta ContaOrigem { get; set; } = null!;
        public long? IdContaDestino { get; set; }
        public Conta? ContaDestino { get; set; }
    }
}
