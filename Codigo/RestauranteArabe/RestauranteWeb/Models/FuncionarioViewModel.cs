using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models;

public class FuncionarioViewModel
{
    public uint Id { get; set; }

    [Required(ErrorMessage = "Informe o nome do funcionário.")]
    [StringLength(45, ErrorMessage = "O nome deve ter no máximo 45 caracteres.")]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o CPF do funcionário.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 números, sem pontos ou traço.")]
    [Display(Name = "CPF")]
    public string Cpf { get; set; } = string.Empty;

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

    [Range(1, uint.MaxValue, ErrorMessage = "Selecione o restaurante.")]
    [Display(Name = "Restaurante")]
    public uint IdRestaurante { get; set; }

    [Range(1, uint.MaxValue, ErrorMessage = "Selecione a função do funcionário.")]
    [Display(Name = "Função")]
    public uint IdTipoFuncionario { get; set; }

    [Display(Name = "Restaurante")]
    public string? NomeRestaurante { get; set; }

    [Display(Name = "Função")]
    public string? NomeTipoFuncionario { get; set; }
}
