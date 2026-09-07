using System.ComponentModel.DataAnnotations;

namespace SistemaConsultasUVV.Models.ViewModels
{
    public class CadastroViewModel
    {
        [Required(ErrorMessage ="O nome é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage ="Informe um e-mail válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="A senha é obrigatória.")]
        [StringLength(100, MinimumLength =6, ErrorMessage ="A senha deve ter no mínimo 6 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = string.Empty;
    }
}
