using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service 
{
    public class TipoFuncionarioService : ITipoFuncionario
    {
        private readonly RestauranteContext context;

        public TipoFuncionarioService(RestauranteContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Insere um novo tipo de funcionário na base de dados e retorna o ID do mesmo.
        /// </summary>
        /// <param name="tipoFuncionario"></param>
        /// <returns></returns>
        public uint Create(Tipofuncionario tipoFuncionario)
        {
            context.Add(tipoFuncionario);
            context.SaveChanges();
            return tipoFuncionario.Id;
        }

        /// <summary>
        /// Remove um tipo de funcionário da base de dados com base no ID fornecido.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(uint id)
        {
            var tipoFuncionario = context.Tipofuncionarios.Find(id);
            if(tipoFuncionario != null)
            {
                context.Remove(tipoFuncionario);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Edita as informações de um tipo de funcionário existente na base de dados.
        /// </summary>
        /// <param name="tipoFuncionario"></param>
        public void Edit(Tipofuncionario tipoFuncionario)
        {
            context.Update(tipoFuncionario);
            context.SaveChanges();
        }
        
        /// <summary>
        /// Buscar um tipo de funcionário na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tipofuncionario? Get(uint id)
        {
            return context.Tipofuncionarios.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Busca todos os tipos de funcionários na base de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Tipofuncionario> GetAll()
        {
            return context.Tipofuncionarios.AsNoTracking();
        }
    }
}
