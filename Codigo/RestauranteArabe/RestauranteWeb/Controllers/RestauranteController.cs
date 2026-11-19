using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Mappers;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers;

public class RestauranteController : Controller
{
    private readonly IRestauranteService _service;
    private readonly ITipoRestauranteService _tipoRestauranteService;

    public RestauranteController(
        IRestauranteService service,
        ITipoRestauranteService tipoRestauranteService)
    {
        _service = service;
        _tipoRestauranteService = tipoRestauranteService;
    }

    public IActionResult Index()
    {
        var restaurantes = _service.GetAll().Select(restaurante => restaurante.ToViewModel());
        return View(restaurantes);
    }

    public IActionResult Details(uint? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var restaurante = _service.Get(id.Value);
        return restaurante is null ? NotFound() : View(restaurante.ToViewModel());
    }

    public IActionResult Create()
    {
        CarregarListas();
        return View(new RestauranteViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(RestauranteViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarListas();
            return View(viewModel);
        }

        Normalizar(viewModel);
        _service.Create(viewModel.ToEntity());
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(uint? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var restaurante = _service.Get(id.Value);
        if (restaurante is null)
        {
            return NotFound();
        }

        CarregarListas();
        return View(restaurante.ToViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(uint id, RestauranteViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            CarregarListas();
            return View(viewModel);
        }

        if (_service.Get(id) is null)
        {
            return NotFound();
        }

        Normalizar(viewModel);
        _service.Edit(viewModel.ToEntity());
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(uint? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var restaurante = _service.Get(id.Value);
        return restaurante is null ? NotFound() : View(restaurante.ToViewModel());
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
            TempData["Error"] = "Este restaurante possui funcionários, mesas ou itens do cardápio vinculados e não pode ser excluído.";
            return RedirectToAction(nameof(Index));
        }
    }

    private void CarregarListas()
    {
        ViewBag.TiposRestaurante = new SelectList(_tipoRestauranteService.GetAll(), nameof(Tiporestaurante.Id), nameof(Tiporestaurante.Nome));
    }

    private static void Normalizar(RestauranteViewModel viewModel)
    {
        viewModel.Nome = viewModel.Nome.Trim();
        viewModel.Cnpj = viewModel.Cnpj.Trim();
        viewModel.Cep = Limpar(viewModel.Cep);
        viewModel.Rua = Limpar(viewModel.Rua);
        viewModel.Bairro = Limpar(viewModel.Bairro);
        viewModel.Cidade = Limpar(viewModel.Cidade);
        viewModel.Estado = Limpar(viewModel.Estado)?.ToUpperInvariant();
        viewModel.Telefone1 = Limpar(viewModel.Telefone1);
        viewModel.Telefone2 = Limpar(viewModel.Telefone2);
    }

    private static string? Limpar(string? valor)
    {
        return string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();
    }
}
