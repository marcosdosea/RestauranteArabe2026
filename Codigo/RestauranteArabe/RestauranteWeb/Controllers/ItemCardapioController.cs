using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestauranteWeb.Mappers;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class ItemCardapioController : Controller
    {
        private readonly IItemCardapioService itemCardapioService;
        private readonly IGrupoCardapioService grupoCardapioService;
        private readonly IRestauranteService restauranteService;

        public ItemCardapioController(IItemCardapioService itemCardapioService, IGrupoCardapioService grupoCardapioService, IRestauranteService restauranteService)
        {
            this.itemCardapioService = itemCardapioService;
            this.grupoCardapioService = grupoCardapioService;
            this.restauranteService = restauranteService;
        }

        private void SelectDeListas(ItemCardapioViewModel model)
        {
            model.ListaGruposCardapio = new SelectList(grupoCardapioService.GetAll(), "Id", "Nome", model.IdGrupoCardapio);
            model.ListaRestaurantes = new SelectList(restauranteService.GetAll(), "Id", "Nome", model.IdRestaurante);
        }

        // GET: ItemCardapioController
        public ActionResult Index()
        {
            var listaItensCardapio = itemCardapioService.GetAll();
            var listaItensCardapioModel = ItemCardapioMapper.ToViewModel(listaItensCardapio);
            return View(listaItensCardapioModel);
        }

        // GET: ItemCardapioController/Details/5
        public ActionResult Details(uint id)
        {
            var itemCardapio = itemCardapioService.Get(id);
            if(itemCardapio == null) 
                return NotFound();
            return View(ItemCardapioMapper.ToViewModel(itemCardapio));
        }

        // GET: ItemCardapioController/Create
        public ActionResult Create()
        {
            var itemCardapioModel = new ItemCardapioViewModel();
            SelectDeListas(itemCardapioModel);
            return View(itemCardapioModel);
        }

        // POST: ItemCardapioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemCardapioViewModel itemCardapioModel)
        {
            if(!ModelState.IsValid)
            {
                SelectDeListas(itemCardapioModel);
                return View(itemCardapioModel);
            }
            var itemCardapio = ItemCardapioMapper.ToEntity(itemCardapioModel);
            itemCardapioService.Create(itemCardapio);
            return RedirectToAction(nameof(Index));

        }

        // GET: ItemCardapioController/Edit/5
        public ActionResult Edit(uint id)
        {
            var itemCardapio = itemCardapioService.Get(id);
            if(itemCardapio == null) 
                return NotFound();
            var itemCardapioModel = ItemCardapioMapper.ToViewModel(itemCardapio);
            SelectDeListas(itemCardapioModel);
            return View(itemCardapioModel);
        }

        // POST: ItemCardapioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ItemCardapioViewModel itemCardapioModel)
        {
            if(id != itemCardapioModel.Id) 
                return BadRequest();

            if(!ModelState.IsValid)
            {
                SelectDeListas(itemCardapioModel);
                return View(itemCardapioModel);
            }

            Itemcardapio itemCardapio = ItemCardapioMapper.ToEntity(itemCardapioModel);
            itemCardapioService.Edit(itemCardapio);
            return RedirectToAction(nameof(Index));
        }

        // GET: ItemCardapioController/Delete/5
        public ActionResult Delete(uint id)
        {
            var itemCardapio = itemCardapioService.Get(id);
            if(itemCardapio == null) 
                return NotFound();
            var itemCardapioModel = ItemCardapioMapper.ToViewModel(itemCardapio);
            return View(itemCardapioModel);
        }

        // POST: ItemCardapioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, ItemCardapioViewModel itemCardapioViewModel)
        {
            itemCardapioService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
