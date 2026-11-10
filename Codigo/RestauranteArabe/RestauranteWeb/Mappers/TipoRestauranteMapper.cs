using Core;
using Mapster;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers;

public static class TipoRestauranteMapper
{
    public static TipoRestauranteViewModel ToViewModel(this Tiporestaurante tipoRestaurante)
    {
        return tipoRestaurante.Adapt<TipoRestauranteViewModel>();
    }

    public static Tiporestaurante ToEntity(this TipoRestauranteViewModel viewModel)
    {
        return viewModel.Adapt<Tiporestaurante>();
    }
}