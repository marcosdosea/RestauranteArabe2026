using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class FormaPagamentoService : IFormaPagamentoService
{
    private readonly RestauranteContext _context;

    public FormaPagamentoService(RestauranteContext context)
    {
        _context = context;
    }

    public uint Create(Formapagamento formaPagamento)
    {
        _context.Formapagamentos.Add(formaPagamento);
        _context.SaveChanges();
        return formaPagamento.Id;
    }

    public void Edit(Formapagamento formaPagamento)
    {
        _context.Formapagamentos.Update(formaPagamento);
        _context.SaveChanges();
    }

    public void Delete(uint id)
    {
        var formaPagamento = Get(id);
        if (formaPagamento is null)
        {
            return;
        }

        _context.Formapagamentos.Remove(formaPagamento);
        _context.SaveChanges();
    }

    public Formapagamento? Get(uint id)
    {
        return _context.Formapagamentos.Find(id);
    }

    public IEnumerable<Formapagamento> GetAll()
    {
        return _context.Formapagamentos
            .AsNoTracking()
            .OrderBy(formaPagamento => formaPagamento.Nome)
            .ToList();
    }
}