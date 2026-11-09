using Core;
using Mapster;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers;

public static class FormaPagamentoMapper
{
    public static FormaPagamentoViewModel ToViewModel(this Formapagamento formaPagamento)
    {
        return formaPagamento.Adapt<FormaPagamentoViewModel>();
    }

    public static Formapagamento ToEntity(this FormaPagamentoViewModel viewModel)
    {
        return viewModel.Adapt<Formapagamento>();
    }
}