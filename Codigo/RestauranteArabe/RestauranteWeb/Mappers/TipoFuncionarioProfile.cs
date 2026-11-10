using Core;
using Mapster;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class TipoFuncionarioProfile
    {
        public static TipoFuncionarioModel ToViewModel(Tipofuncionario tipoFuncionario)
        {
            return tipoFuncionario.Adapt<TipoFuncionarioModel>();
        }

        public static Tipofuncionario ToEntity(TipoFuncionarioModel tipoFuncionarioModel)
        {
            return tipoFuncionarioModel.Adapt<Tipofuncionario>();
        }

        public static IEnumerable<TipoFuncionarioModel> ToViewModel(IEnumerable<Tipofuncionario>? listaTipoFuncionarios)
        {
            return listaTipoFuncionarios.Adapt<IEnumerable<TipoFuncionarioModel>>() ?? new List<TipoFuncionarioModel>();
        }

        public static IEnumerable<Tipofuncionario> ToEntity(IEnumerable<TipoFuncionarioModel>? listaTipoFuncionariosModel)
        {
            return listaTipoFuncionariosModel?.Adapt<IEnumerable<Tipofuncionario>>() ?? new List<Tipofuncionario>();
        }
    }
}
