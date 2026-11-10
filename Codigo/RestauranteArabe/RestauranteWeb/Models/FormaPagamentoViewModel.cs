using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models;

public class FormaPagamentoViewModel
{
    public uint Id { get; set; }

    [Required(ErrorMessage = "Informe o nome da forma de pagamento.")]
    [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;
}