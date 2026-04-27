using Sistema_Bancario_Sprint3.Models.ENUM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Bancario_Sprint3.Models
{
    public class Conta
    {
        
        public long Id { get; set; }       
        
        public string NumeroConta { get; set; }
        
        public string Agencia { get; set; }
        public decimal Saldo { get; set; }
        public Status Status { get; set; }
        public TipoConta TipoConta { get; set; }   
        public DateTime DataAbertura { get; set; }        
        public long IdCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;

    }
}