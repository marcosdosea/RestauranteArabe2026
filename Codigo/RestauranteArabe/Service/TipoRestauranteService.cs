using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class TipoRestauranteService : ITipoRestauranteService
{
    private readonly RestauranteContext _context;

    public TipoRestauranteService(RestauranteContext context)
    {
        _context = context;
    }

    public uint Create(Tiporestaurante tipoRestaurante)
    {
        _context.Tiporestaurantes.Add(tipoRestaurante);
        _context.SaveChanges();
        return tipoRestaurante.Id;
    }

    public void Edit(Tiporestaurante tipoRestaurante)
    {
        _context.Tiporestaurantes.Update(tipoRestaurante);
        _context.SaveChanges();
    }

    public void Delete(uint id)
    {
        var tipoRestaurante = Get(id);
        if (tipoRestaurante is null)
        {
            return;
        }

        _context.Tiporestaurantes.Remove(tipoRestaurante);
        _context.SaveChanges();
    }

    public Tiporestaurante? Get(uint id)
    {
        return _context.Tiporestaurantes.Find(id);
    }

    public IEnumerable<Tiporestaurante> GetAll()
    {
        return _context.Tiporestaurantes
            .AsNoTracking()
            .OrderBy(tipoRestaurante => tipoRestaurante.Nome)
            .ToList();
    }
}