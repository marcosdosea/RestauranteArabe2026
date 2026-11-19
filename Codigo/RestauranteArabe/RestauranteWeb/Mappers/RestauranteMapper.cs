using Core;
using Mapster;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers;

public static class RestauranteMapper
{
    public static RestauranteViewModel ToViewModel(this Restaurante restaurante)
    {
        var viewModel = restaurante.Adapt<RestauranteViewModel>();
        viewModel.NomeTipoRestaurante = restaurante.IdTipoRestauranteNavigation?.Nome;
        return viewModel;
    }

    public static Restaurante ToEntity(this RestauranteViewModel viewModel)
    {
        return new Restaurante
        {
            Id = viewModel.Id,
            Nome = viewModel.Nome,
            Cnpj = viewModel.Cnpj,
            Cep = viewModel.Cep,
            Rua = viewModel.Rua,
            Bairro = viewModel.Bairro,
            Cidade = viewModel.Cidade,
            Estado = viewModel.Estado,
            Telefone1 = viewModel.Telefone1,
            Telefone2 = viewModel.Telefone2,
            IdTipoRestaurante = viewModel.IdTipoRestaurante
        };
    }
}
