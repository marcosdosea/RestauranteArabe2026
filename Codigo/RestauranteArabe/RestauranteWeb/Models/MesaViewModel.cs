using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models;

public class MesaViewModel
{
    [Display(Name = "Código")]
    [Key]
    public uint Id { get; set; }

    [Display(Name = "Identificação")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(45, MinimumLength = 1, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
    public string Identificacao { get; set; } = null!;

    [Display(Name = "Restaurante")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public uint IdRestaurante { get; set; }

    [Display(Name = "Restaurante")]
    public string? NomeRestaurante { get; set; }
}
