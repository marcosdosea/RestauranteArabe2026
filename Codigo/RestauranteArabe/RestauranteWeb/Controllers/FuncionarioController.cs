using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Mappers;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers;

public class FuncionarioController : Controller
{
    private readonly IFuncionarioService _service;
    private readonly IRestauranteService _restauranteService;
    private readonly ITipoFuncionario _tipoFuncionarioService;

    public FuncionarioController(
        IFuncionarioService service,
        IRestauranteService restauranteService,
        ITipoFuncionario tipoFuncionarioService)
    {
        _service = service;
        _restauranteService = restauranteService;
        _tipoFuncionarioService = tipoFuncionarioService;
    }

    public IActionResult Index()
    {
        var funcionarios = _service.GetAll().Select(funcionario => funcionario.ToViewModel());
        return View(funcionarios);
    }

    public IActionResult Details(uint? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var funcionario = _service.Get(id.Value);
        return funcionario is null ? NotFound() : View(funcionario.ToViewModel());
    }

    public IActionResult Create()
    {
        CarregarListas();
        return View(new FuncionarioViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(FuncionarioViewModel viewModel)
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

        var funcionario = _service.Get(id.Value);
        if (funcionario is null)
        {
            return NotFound();
        }

        CarregarListas();
        return View(funcionario.ToViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(uint id, FuncionarioViewModel viewModel)
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

        var funcionario = _service.Get(id.Value);
        return funcionario is null ? NotFound() : View(funcionario.ToViewModel());
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
            TempData["Error"] = "Este funcionário já está vinculado a algum pedido e não pode ser excluído.";
            return RedirectToAction(nameof(Index));
        }
    }

    private void CarregarListas()
    {
        ViewBag.Restaurantes = new SelectList(_restauranteService.GetAll(), nameof(Restaurante.Id), nameof(Restaurante.Nome));
        ViewBag.TiposFuncionario = new SelectList(
            _tipoFuncionarioService.GetAll().OrderBy(tipoFuncionario => tipoFuncionario.Nome),
            nameof(Tipofuncionario.Id),
            nameof(Tipofuncionario.Nome));
    }

    private static void Normalizar(FuncionarioViewModel viewModel)
    {
        viewModel.Nome = viewModel.Nome.Trim();
        viewModel.Cpf = viewModel.Cpf.Trim();
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
