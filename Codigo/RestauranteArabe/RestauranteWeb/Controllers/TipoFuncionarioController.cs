using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Mappers;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class TipoFuncionarioController : Controller
    {
        private readonly ITipoFuncionario tipoFuncionarioService;
        public TipoFuncionarioController(ITipoFuncionario tipoFuncionarioService)
        {
            this.tipoFuncionarioService = tipoFuncionarioService;
        }

        // GET: TipoFuncionarioController
        public ActionResult Index()
        {
            var listaTiposFuncionario = tipoFuncionarioService.GetAll();
            var listaTiposFuncionarioModel = TipoFuncionarioProfile.ToViewModel(listaTiposFuncionario);
            return View(listaTiposFuncionarioModel);
        }

        // GET: TipoFuncionarioController/Details/5
        public ActionResult Details(uint id)
        {
            Tipofuncionario tipoFuncionario = tipoFuncionarioService.Get(id);
            TipoFuncionarioModel tipoFuncionarioModel = TipoFuncionarioProfile.ToViewModel(tipoFuncionario);
            return View(tipoFuncionarioModel);
        }

        // GET: TipoFuncionarioController/Create
        public ActionResult Create()
        {
            var tipoFuncionarioModel = new TipoFuncionarioModel();
            return View(tipoFuncionarioModel);
        }

        // POST: TipoFuncionarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoFuncionarioModel tipoFuncionarioModel)
        {
            if (ModelState.IsValid)
            {
                Tipofuncionario tipoFuncionario = TipoFuncionarioProfile.ToEntity(tipoFuncionarioModel);
                tipoFuncionarioService.Create(tipoFuncionario);          
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipoFuncionarioController/Edit/5
        public ActionResult Edit(uint id)
        {
            var tipoFuncionario = tipoFuncionarioService.Get(id);
            var tipoFuncionarioModel = TipoFuncionarioProfile.ToViewModel(tipoFuncionario);
            return View(tipoFuncionarioModel);
        }

        // POST: TipoFuncionarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, TipoFuncionarioModel tipoFuncionarioModel)
        {      
            if (ModelState.IsValid)
            {
                Tipofuncionario tipoFuncionario = TipoFuncionarioProfile.ToEntity(tipoFuncionarioModel);
                tipoFuncionarioService.Edit(tipoFuncionario);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipoFuncionarioController/Delete/5
        public ActionResult Delete(uint id)
        {
            var tipoFuncionario = tipoFuncionarioService.Get(id);
            var tipoFuncionarioModel = TipoFuncionarioProfile.ToViewModel(tipoFuncionario);
            return View(tipoFuncionarioModel);
        }

        // POST: TipoFuncionarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, TipoFuncionarioModel tipoFuncionarioModel)
        {
            tipoFuncionarioService.Delete(tipoFuncionarioModel.Id);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
