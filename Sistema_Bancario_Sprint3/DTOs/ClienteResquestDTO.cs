using Sistema_Bancario_Sprint3.Models.ENUM;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Bancario_Sprint3.DTOs
{
    public class ClienteResquestDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100)]
        public string Nome { get; set; }
        
        [EmailAddress(ErrorMessage = "Email inválido.")]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }
        
        [Required]
        public TipoPessoa TipoPessoa { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ é obrigatório.")]
        public string cpfCnpj { get; set; }

    }
}
