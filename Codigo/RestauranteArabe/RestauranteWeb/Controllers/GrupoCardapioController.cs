using Core.Service;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Mappers;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers;

public class GrupoCardapioController : Controller
{
    private readonly IGrupoCardapioService grupoCardapioService;

    public GrupoCardapioController(IGrupoCardapioService grupoCardapioService)
    {
        this.grupoCardapioService = grupoCardapioService;
    }
    
    // GET: GrupoCardapioController
    public ActionResult Index()
    {
        var gruposCardapio = grupoCardapioService.GetAll();
        var gruposCardapioViewModel = GrupoCardapioMapper.ToViewModel(gruposCardapio);
        return View(gruposCardapioViewModel);
    }
    
    // GET: GrupoCardapioController/Details/5
    public ActionResult Details(uint id)
    {
        var grupoCardapio = grupoCardapioService.Get(id);
        var grupoCardapioViewModel = GrupoCardapioMapper.ToViewModel(grupoCardapio);
        return View(grupoCardapioViewModel);
    }
    
    // GET: GrupoCardapioController/Create
    public ActionResult Create()
    {
        var grupoCardapioViewModel = new GrupoCardapioViewModel();
        return View(grupoCardapioViewModel);
    }
    
    // POST: GrupoCardapioController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(GrupoCardapioViewModel grupoCardapioViewModel)
    {
        if (ModelState.IsValid)
        {
            var grupoCardapio = GrupoCardapioMapper.ToEntity(grupoCardapioViewModel);
            grupoCardapioService.Create(grupoCardapio);
        }
        return RedirectToAction(nameof(Index));
    }
    
    // GET: GrupoCardapioController/Edit/5
    public ActionResult Edit(uint id)
    {
        var grupoCardapio = grupoCardapioService.Get(id);
        var grupoCardapioViewModel = GrupoCardapioMapper.ToViewModel(grupoCardapio);
        return View(grupoCardapioViewModel);
    }

    // POST: GrupoCardapioController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(GrupoCardapioViewModel grupoCardapioViewModel)
    {
        if (ModelState.IsValid)
        {
            var grupoCardapio = GrupoCardapioMapper.ToEntity(grupoCardapioViewModel);
            grupoCardapioService.Edit(grupoCardapio);
        }
        return RedirectToAction(nameof(Index));
    }
    
    // GET: GrupoCardapioController/Delete/5
    public ActionResult Delete(uint id)
    {
        var grupoCardapio = grupoCardapioService.Get(id);
        var grupoCardapioViewModel = GrupoCardapioMapper.ToViewModel(grupoCardapio);
        return View(grupoCardapioViewModel);
    }

    // POST: GrupoCardapioController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(GrupoCardapioViewModel grupoCardapioViewModel)
    {
        grupoCardapioService.Delete(grupoCardapioViewModel.Id);
        return RedirectToAction(nameof(Index));
    }
}