using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class RestauranteService : IRestauranteService
{
    private readonly RestauranteContext _context;

    public RestauranteService(RestauranteContext context)
    {
        _context = context;
    }

    public uint Create(Restaurante restaurante)
    {
        _context.Restaurantes.Add(restaurante);
        _context.SaveChanges();
        return restaurante.Id;
    }

    public void Edit(Restaurante restaurante)
    {
        _context.Restaurantes.Update(restaurante);
        _context.SaveChanges();
    }

    public void Delete(uint id)
    {
        var restaurante = Get(id);
        if (restaurante is null)
        {
            return;
        }

        _context.Restaurantes.Remove(restaurante);
        _context.SaveChanges();
    }

    public Restaurante? Get(uint id)
    {
        return _context.Restaurantes.Find(id);
    }

    public IEnumerable<Restaurante> GetAll()
    {
        return _context.Restaurantes
            .AsNoTracking()
            .OrderBy(restaurante => restaurante.Nome)
            .ToList();
    }
}
