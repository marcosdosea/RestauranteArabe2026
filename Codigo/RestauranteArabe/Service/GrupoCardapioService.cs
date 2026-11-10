using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class GrupoCardapioService : IGrupoCardapioService
{
    
    private RestauranteContext context;

    public GrupoCardapioService(RestauranteContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Cria um novo grupo do cardápio no banco de dados e retorna o id do grupo criado.
    /// </summary>
    /// <param name="grupoCardapio"> O grupo a ser criado. </param>
    /// <returns> O id do grupo criado. </returns>
    public uint Create(Grupocardapio grupoCardapio)
    {
        context.Add(grupoCardapio);
        context.SaveChanges();
        return grupoCardapio.Id;
    }

    /// <summary>
    /// Alterar os dados do grupo na base de dados
    /// </summary>
    /// <param name="grupoCardapio"> O grupo a ser alterado. </param>
    public void Edit(Grupocardapio grupoCardapio)
    {
        context.Update(grupoCardapio);
        context.SaveChanges();
    }

    /// <summary>
    /// Exclui um grupo do banco de dados com base no id fornecido. Se o grupo não for encontrado, nenhuma ação será realizada.
    /// </summary>
    /// <param name="id"> O id do grupo a ser excluído. </param>
    public void Delete(uint id)
    {
        var grupoCardapio = context.Grupocardapios.Find(id);
        if (grupoCardapio == null) return;
        context.Remove(grupoCardapio);
        context.SaveChanges();
    }

    /// <summary>
    /// Obtém um grupo do cardápio pelo id.
    /// </summary>
    /// <param name="id">id do grupo</param>
    /// <returns></returns>
    public Grupocardapio? Get(uint id)
    {
        return context.Grupocardapios.Find(id);
    }

    /// <summary>
    /// Obtém todos os grupos do cardápio existentes no banco de dados.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Grupocardapio> GetAll()
    {
        return context.Grupocardapios.AsNoTracking();
    }
}