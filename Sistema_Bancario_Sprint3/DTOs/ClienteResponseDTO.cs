using Sistema_Bancario_Sprint3.Models.ENUM;

namespace Sistema_Bancario_Sprint3.DTOs
{
    public class ClienteResponseDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public TipoPessoa TipoPessoa { get; set; }        
        public DateTime DataCadastro { get; set; }
    }  
}
