namespace Sistema_Bancario_Sprint3.Models
{
    public class Transacao
    {
        public long Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;
        public long FK_conta_origem { get; set; }
        public Conta ContaOrigem { get; set; } = null!;
        public long? FK_conta_destino { get; set; }
        public Conta? ContaDestino { get; set; }
    }
}
