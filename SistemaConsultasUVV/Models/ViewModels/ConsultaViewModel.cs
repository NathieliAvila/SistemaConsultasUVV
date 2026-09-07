using System.ComponentModel.DataAnnotations;


namespace SistemaConsultasUVV.Models.ViewModels
{
    public class ConsultaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A especialidade é obrigatória.")]
        [StringLength(100)]
        public string Especialidade { get; set; } = string.Empty;

        [Required(ErrorMessage ="Informe a data e hora.")]
        [DataType(DataType.DateTime)]
        [Display(Name ="Data e Hora")]
        public DateTime DataHora { get; set; }

        [StringLength(500)]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

    }
}
