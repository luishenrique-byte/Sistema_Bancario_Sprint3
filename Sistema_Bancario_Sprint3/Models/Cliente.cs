using Sistema_Bancario_Sprint3.Models.ENUM;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Bancario_Sprint3.Models
{
    public class Cliente
    {
        
        public long Id { get; set; }                
        public string Nome { get; set; }        
        public string Email { get; set; }        
        public string Telefone { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string cpfCnpj { get; set; }       
        public DateTime DataCadastro { get; set; }        
        public List<Conta> Contas { get; set; } = new List<Conta>();
    }
}
