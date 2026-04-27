namespace Sistema_Bancario_Sprint3.Models
{
    public class TipoConta
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public List<Conta> Contas { get; set; } = new List<Conta>();
    }
}
