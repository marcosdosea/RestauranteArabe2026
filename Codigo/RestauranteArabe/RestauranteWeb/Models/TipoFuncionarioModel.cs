using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class TipoFuncionarioModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "O código do tipo de funcionário é obrigatório")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O nome do tipo de funcionário deve ter entre 5 e 20 caracteres")]
        public string Nome { get; set; } 


    }
}
