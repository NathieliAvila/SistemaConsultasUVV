using System.ComponentModel.DataAnnotations;

namespace SistemaConsultasUVV.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="O e-mail é obrigatório.")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = string.Empty;
    }
}
