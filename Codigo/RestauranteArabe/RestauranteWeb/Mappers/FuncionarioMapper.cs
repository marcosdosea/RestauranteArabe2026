using Core;
using Mapster;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers;

public static class FuncionarioMapper
{
    public static FuncionarioViewModel ToViewModel(this Funcionario funcionario)
    {
        var viewModel = funcionario.Adapt<FuncionarioViewModel>();
        viewModel.NomeRestaurante = funcionario.IdRestauranteNavigation?.Nome;
        viewModel.NomeTipoFuncionario = funcionario.IdTipoFuncionarioNavigation?.Nome;
        return viewModel;
    }

    public static Funcionario ToEntity(this FuncionarioViewModel viewModel)
    {
        return new Funcionario
        {
            Id = viewModel.Id,
            Nome = viewModel.Nome,
            Cpf = viewModel.Cpf,
            Cep = viewModel.Cep,
            Rua = viewModel.Rua,
            Bairro = viewModel.Bairro,
            Cidade = viewModel.Cidade,
            Estado = viewModel.Estado,
            Telefone1 = viewModel.Telefone1,
            Telefone2 = viewModel.Telefone2,
            IdRestaurante = viewModel.IdRestaurante,
            IdTipoFuncionario = viewModel.IdTipoFuncionario
        };
    }
}
