using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestauranteWeb.Mappers;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers;

public class MesaController : Controller
{
    private readonly IMesaService mesaService;
    private readonly IRestauranteService restauranteService;

    public MesaController(
        IMesaService mesaService,
        IRestauranteService restauranteService)
    {
        this.mesaService = mesaService;
        this.restauranteService = restauranteService;
    }

    // GET: MesaController
    public ActionResult Index()
    {
        var mesas = mesaService.GetAll();
        var mesasViewModel = MesaMapper.ToViewModel(mesas);
        return View(mesasViewModel);
    }

    // GET: MesaController/Details/5
    public ActionResult Details(uint id)
    {
        var mesa = mesaService.Get(id);
        if(mesa == null) 
            return NotFound();
        var mesaViewModel = MesaMapper.ToViewModel(mesa);
        return View(mesaViewModel);
    }

    // GET: MesaController/Create
    public ActionResult Create()
    {
        CarregarListas();
        return View(new MesaViewModel());
    }

    // POST: MesaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(MesaViewModel mesaViewModel)
    {
        if (ModelState.IsValid)
        {
            var mesa = MesaMapper.ToEntity(mesaViewModel);
            mesaService.Create(mesa);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: MesaController/Edit/5
    public ActionResult Edit(uint id)
    {
        var mesa = mesaService.Get(id);
        if(mesa == null) 
            return NotFound();
        var mesaViewModel = MesaMapper.ToViewModel(mesa);
        CarregarListas();
        return View(mesaViewModel);
    }

    // POST: MesaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(MesaViewModel mesaViewModel)
    {
        if (ModelState.IsValid)
        {
            var mesa = MesaMapper.ToEntity(mesaViewModel);
            mesaService.Edit(mesa);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: MesaController/Delete/5
    public ActionResult Delete(uint id)
    {
        var mesa = mesaService.Get(id);
        if(mesa == null) 
            return NotFound();
        var mesaViewModel = MesaMapper.ToViewModel(mesa);
        return View(mesaViewModel);
    }

    // POST: MesaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(MesaViewModel mesaViewModel)
    {
        mesaService.Delete(mesaViewModel.Id);
        return RedirectToAction(nameof(Index));
    }

    private void CarregarListas()
    {
        ViewBag.Restaurantes = new SelectList(restauranteService.GetAll(), nameof(Restaurante.Id), nameof(Restaurante.Nome));
    }
}
