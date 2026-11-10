using RestauranteWeb.Models;
using Core;
using Mapster;

namespace RestauranteWeb.Mappers;

public class GrupoCardapioMapper
{
    public static GrupoCardapioViewModel ToViewModel(Grupocardapio grupoCardapio)
    {
        return grupoCardapio.Adapt<GrupoCardapioViewModel>();
    }

    public static Grupocardapio ToEntity(GrupoCardapioViewModel grupoCardapioViewModel)
    {
        return grupoCardapioViewModel.Adapt<Grupocardapio>();
    }

    public static IEnumerable<GrupoCardapioViewModel> ToViewModel(IEnumerable<Grupocardapio> gruposCardapio)
    {
        return gruposCardapio.Adapt<IEnumerable<GrupoCardapioViewModel>>();
    }

    public static IEnumerable<Grupocardapio> ToEntity(IEnumerable<GrupoCardapioViewModel> gruposCardapioViewModel)
    {
        return gruposCardapioViewModel.Adapt<IEnumerable<Grupocardapio>>();
    }
}