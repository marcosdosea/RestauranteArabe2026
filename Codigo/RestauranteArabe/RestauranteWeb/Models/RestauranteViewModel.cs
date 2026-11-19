using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models;

public class RestauranteViewModel
{
    public uint Id { get; set; }

    [Required(ErrorMessage = "Informe o nome do restaurante.")]
    [StringLength(45, ErrorMessage = "O nome deve ter no máximo 45 caracteres.")]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o CNPJ do restaurante.")]
    [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve conter 14 números, sem pontos, barra ou traço.")]
    [Display(Name = "CNPJ")]
    public string Cnpj { get; set; } = string.Empty;

    [RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP deve conter 8 números, sem traço.")]
    [Display(Name = "CEP")]
    public string? Cep { get; set; }

    [StringLength(45, ErrorMessage = "A rua deve ter no máximo 45 caracteres.")]
    [Display(Name = "Rua")]
    public string? Rua { get; set; }

    [StringLength(45, ErrorMessage = "O bairro deve ter no máximo 45 caracteres.")]
    [Display(Name = "Bairro")]
    public string? Bairro { get; set; }

    [StringLength(45, ErrorMessage = "A cidade deve ter no máximo 45 caracteres.")]
    [Display(Name = "Cidade")]
    public string? Cidade { get; set; }

    [RegularExpression(@"^[A-Za-z]{2}$", ErrorMessage = "Informe a sigla do estado com 2 letras.")]
    [Display(Name = "Estado (UF)")]
    public string? Estado { get; set; }

    [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O telefone deve conter DDD e número, com 10 ou 11 números.")]
    [Display(Name = "Telefone")]
    public string? Telefone1 { get; set; }

    [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O telefone deve conter DDD e número, com 10 ou 11 números.")]
    [Display(Name = "Telefone secundário")]
    public string? Telefone2 { get; set; }

    [Range(1, uint.MaxValue, ErrorMessage = "Selecione o tipo de restaurante.")]
    [Display(Name = "Tipo de restaurante")]
    public uint IdTipoRestaurante { get; set; }

    [Display(Name = "Tipo de restaurante")]
    public string? NomeTipoRestaurante { get; set; }
}
