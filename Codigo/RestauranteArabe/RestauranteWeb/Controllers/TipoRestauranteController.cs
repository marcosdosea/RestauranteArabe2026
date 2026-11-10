using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Mappers;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers;

public class TipoRestauranteController : Controller
{
    private readonly ITipoRestauranteService _service;

    public TipoRestauranteController(ITipoRestauranteService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var tiposRestaurante = _service.GetAll().Select(tipoRestaurante => tipoRestaurante.ToViewModel());
        return View(tiposRestaurante);
    }

    public IActionResult Create()
    {
        return View(new TipoRestauranteViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TipoRestauranteViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        viewModel.Nome = viewModel.Nome.Trim();
        var tipoRestaurante = viewModel.ToEntity();
        _service.Create(tipoRestaurante);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(uint? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var tipoRestaurante = _service.Get(id.Value);
        return tipoRestaurante is null ? NotFound() : View(tipoRestaurante.ToViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(uint id, TipoRestauranteViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var tipoRestaurante = _service.Get(id);
        if (tipoRestaurante is null)
        {
            return NotFound();
        }

        tipoRestaurante.Nome = viewModel.Nome.Trim();
        _service.Edit(tipoRestaurante);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(uint? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var tipoRestaurante = _service.Get(id.Value);
        return tipoRestaurante is null ? NotFound() : View(tipoRestaurante.ToViewModel());
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
            TempData["Error"] = "Este tipo de restaurante já está sendo usado por algum restaurante e não pode ser excluído.";
            return RedirectToAction(nameof(Index));
        }
    }

}