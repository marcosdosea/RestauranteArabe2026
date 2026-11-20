using RestauranteWeb.Models;
using Core;
using Mapster;

namespace RestauranteWeb.Mappers;

public class MesaMapper
{
    public static MesaViewModel ToViewModel(Mesa mesa)
    {
        return mesa.Adapt<MesaViewModel>();
    }

    public static Mesa ToEntity(MesaViewModel mesaViewModel)
    {
        return mesaViewModel.Adapt<Mesa>();
    }

    public static IEnumerable<MesaViewModel> ToViewModel(IEnumerable<Mesa> mesas)
    {
        return mesas.Adapt<IEnumerable<MesaViewModel>>();
    }

    public static IEnumerable<Mesa> ToEntity(IEnumerable<MesaViewModel> mesasViewModel)
    {
        return mesasViewModel.Adapt<IEnumerable<Mesa>>();
    }
}
