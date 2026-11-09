using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models;

public class TipoRestauranteViewModel
{
    public uint Id { get; set; }

    [Required(ErrorMessage = "Informe o nome do tipo de restaurante.")]
    [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;
}