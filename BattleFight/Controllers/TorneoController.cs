using BattleFight.Models;
using BattleFight.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleFight.Controllers
{
    public class TorneoController : Controller
    {
        private Services service;


        public TorneoController()
        {
            this.service = new Services();
        }
        // GET: ProductoController
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            ViewBag.equipos = service.mostrarTorneos();
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Torneo torneo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.agregarTorneo(torneo);
                    return RedirectToAction("Index");
                }
            }
            catch { }
            return View();
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            var torneoBuscado = service.buscarTorneos(id);
            return View(torneoBuscado);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Equipo equipo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.actualizarEquipo(equipo);
                    return RedirectToAction("Index");
                }
            }
            catch { }
            return View();
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var torneoBuscado = service.buscarTorneos(id);
                service.eliminarTorneo(torneoBuscado);
                return RedirectToAction("Index");
            }

            catch (Exception) { }
            return View();
        }
    }
}
