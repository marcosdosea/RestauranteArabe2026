using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class ItemCardapioViewModel
    {
        [Display(Name = "Código")]
        public uint Id { get; set; }

        [Display(Name = "Item")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome do item deve ter entre 5 e 100 caracteres")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Informe o preço")]
        [Range(0.01, 99999999.99, ErrorMessage = "Informe um preço válido")]
        public decimal? Preco { get; set; }

        [StringLength(500, ErrorMessage = "Os detalhes devem ter no máximo 500 caracteres")]
        public string? Detalhes { get; set; }

        [Display(Name = "Disponibilidade")]
        [Range(0, 1)]
        public sbyte Ativo { get; set; } = 1;

        [BindNever]
        public string Disponivel { get; set; } = "1";

        [BindNever]
        [Display(Name = "Restaurante")]
        public string? NomeRestaurante { get; set; }

        [BindNever]
        [Display(Name = "Grupo")]
        public string? NomeGrupoCardapio { get; set; }

        [Display(Name = "Restaurante")]
        [Required(ErrorMessage = "Selecione um restaurante")]
        public uint? IdRestaurante { get; set; }        

        [Display(Name = "Grupo")]
        [Required(ErrorMessage = "Selecione um grupo")]
        public uint? IdGrupoCardapio { get; set; }

        public IEnumerable<SelectListItem> ListaRestaurantes { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> ListaGruposCardapio { get; set; } = new List<SelectListItem>();
    }
}
