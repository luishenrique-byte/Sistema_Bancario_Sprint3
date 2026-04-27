namespace Sistema_Bancario_Sprint3.Models
{
    public class ContaEmpresarial : Conta
    {       
        public string CpnjVinculado { get; set; } = string.Empty;
        public decimal limiteCredito { get; set; }
    }
}
