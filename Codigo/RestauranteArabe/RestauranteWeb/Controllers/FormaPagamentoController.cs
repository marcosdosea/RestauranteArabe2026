using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Mappers;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers;

public class FormaPagamentoController : Controller
{
    private readonly IFormaPagamentoService _service;

    public FormaPagamentoController(IFormaPagamentoService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var formasPagamento = _service.GetAll().Select(formaPagamento => formaPagamento.ToViewModel());
        return View(formasPagamento);
    }

    public IActionResult Details(uint? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var formaPagamento = _service.Get(id.Value);
        return formaPagamento is null ? NotFound() : View(formaPagamento.ToViewModel());
    }

    public IActionResult Create()
    {
        return View(new FormaPagamentoViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(FormaPagamentoViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        viewModel.Nome = viewModel.Nome.Trim();
        var formaPagamento = viewModel.ToEntity();
        _service.Create(formaPagamento);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(uint? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var formaPagamento = _service.Get(id.Value);
        return formaPagamento is null ? NotFound() : View(formaPagamento.ToViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(uint id, FormaPagamentoViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var formaPagamento = _service.Get(id);
        if (formaPagamento is null)
        {
            return NotFound();
        }

        formaPagamento.Nome = viewModel.Nome.Trim();
        _service.Edit(formaPagamento);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(uint? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var formaPagamento = _service.Get(id.Value);
        return formaPagamento is null ? NotFound() : View(formaPagamento.ToViewModel());
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(uint id)
    {
        if (_service.Get(id) is null)
        {
            return NotFound();
        }

        try
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException)
        {
            TempData["Error"] = "Esta forma de pagamento já está sendo usada e não pode ser excluída.";
            return RedirectToAction(nameof(Index));
        }
    }

}