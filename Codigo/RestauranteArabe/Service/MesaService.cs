using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class MesaService : IMesaService
{
    
    private RestauranteContext context;

    public MesaService(RestauranteContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Cria uma nova mesa no banco de dados e retorna o id da mesa criada.
    /// </summary>
    /// <param name="mesa"> A mesa a ser criada. </param>
    /// <returns> O id da mesa criada. </returns>
    public uint Create(Mesa mesa)
    {
        context.Add(mesa);
        context.SaveChanges();
        return mesa.Id;
    }

    /// <summary>
    /// Alterar os dados da mesa na base de dados
    /// </summary>
    /// <param name="mesa"> A mesa a ser alterada. </param>
    public void Edit(Mesa mesa)
    {
        context.Update(mesa);
        context.SaveChanges();
    }

    /// <summary>
    /// Exclui uma mesa do banco de dados com base no id fornecido. Se a mesa não for encontrada, nenhuma ação será realizada.
    /// </summary>
    /// <param name="id"> O id da mesa a ser excluída. </param>
    public void Delete(uint id)
    {
        var mesa = context.Mesas.Find(id);
        if (mesa == null) return;
        context.Remove(mesa);
        context.SaveChanges();
    }

    /// <summary>
    /// Obtém uma mesa pelo id.
    /// </summary>
    /// <param name="id">id da mesa</param>
    /// <returns></returns>
    public Mesa? Get(uint id)
    {
        return context.Mesas.Find(id);
    }

    /// <summary>
    /// Obtém todas as mesas existentes no banco de dados.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Mesa> GetAll()
    {
        return context.Mesas.AsNoTracking();
    }
}
