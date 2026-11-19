using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class FuncionarioService : IFuncionarioService
{
    private readonly RestauranteContext _context;

    public FuncionarioService(RestauranteContext context)
    {
        _context = context;
    }

    public uint Create(Funcionario funcionario)
    {
        _context.Funcionarios.Add(funcionario);
        _context.SaveChanges();
        return funcionario.Id;
    }

    public void Edit(Funcionario funcionario)
    {
        _context.Funcionarios.Update(funcionario);
        _context.SaveChanges();
    }

    public void Delete(uint id)
    {
        var funcionario = _context.Funcionarios.Find(id);
        if (funcionario is null)
        {
            return;
        }

        _context.Funcionarios.Remove(funcionario);
        _context.SaveChanges();
    }

    public Funcionario? Get(uint id)
    {
        return _context.Funcionarios
            .AsNoTracking()
            .Include(funcionario => funcionario.IdRestauranteNavigation)
            .Include(funcionario => funcionario.IdTipoFuncionarioNavigation)
            .FirstOrDefault(funcionario => funcionario.Id == id);
    }

    public IEnumerable<Funcionario> GetAll()
    {
        return _context.Funcionarios
            .AsNoTracking()
            .Include(funcionario => funcionario.IdRestauranteNavigation)
            .Include(funcionario => funcionario.IdTipoFuncionarioNavigation)
            .OrderBy(funcionario => funcionario.Nome)
            .ToList();
    }

    public IEnumerable<Funcionario> GetByNome(string nome)
    {
        return _context.Funcionarios
            .AsNoTracking()
            .Include(funcionario => funcionario.IdRestauranteNavigation)
            .Include(funcionario => funcionario.IdTipoFuncionarioNavigation)
            .Where(funcionario => funcionario.Nome.Contains(nome))
            .OrderBy(funcionario => funcionario.Nome)
            .ToList();
    }
}
