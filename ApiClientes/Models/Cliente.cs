using System.ComponentModel.DataAnnotations;

namespace ApiClientes.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        [StringLength(100, ErrorMessage = "O email deve conter no máximo 100 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 dígitos.")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "O telefone do cliente é um campo obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O telefone deve ter no máximo 15 caracteres")]
        public string Telefone { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(200)]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(100)]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O estado deve ter exatamente 2 caracteres (UF).")]
        public string Estado { get; set; } = string.Empty;


        public bool Ativo { get; set; } = true; 
    }
}