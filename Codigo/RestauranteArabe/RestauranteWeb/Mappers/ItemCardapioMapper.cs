
using Core;
using Mapster;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class ItemCardapioMapper
    {
        private static readonly TypeAdapterConfig Config = CriarConfiguracao();

        private static TypeAdapterConfig CriarConfiguracao()
        {
            var config = new TypeAdapterConfig();

            config.NewConfig<Itemcardapio, ItemCardapioViewModel>()
                .Map(
                    destino => destino.NomeRestaurante,
                    origem => origem.IdRestauranteNavigation.Nome
                )
                .Map(
                    destino => destino.NomeGrupoCardapio,
                    origem => origem.IdGrupoCardapioNavigation.Nome
                );

            return config;
        }

        public static ItemCardapioViewModel ToViewModel(Itemcardapio itemCardapio)
        {
            return itemCardapio.Adapt<ItemCardapioViewModel>(Config);
        }

        public static Itemcardapio ToEntity(ItemCardapioViewModel itemCardapioViewModel)
        {
            return itemCardapioViewModel.Adapt<Itemcardapio>(Config);
        }

        public static IEnumerable<ItemCardapioViewModel> ToViewModel(
            IEnumerable<Itemcardapio>? listaItemCardapios)
        {
            return listaItemCardapios?
                .Adapt<IEnumerable<ItemCardapioViewModel>>(Config)
                ?? new List<ItemCardapioViewModel>();
        }

        public static IEnumerable<Itemcardapio> ToEntity(
            IEnumerable<ItemCardapioViewModel>? listaItemCardapiosModel)
        {
            return listaItemCardapiosModel?
                .Adapt<IEnumerable<Itemcardapio>>(Config)
                ?? new List<Itemcardapio>();
        }
    }
}
