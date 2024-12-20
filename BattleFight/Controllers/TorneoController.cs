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
            var model = service.mostrarTorneos();   
            return View(model);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
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
            catch(Exception e){ throw new Exception(e.Message); }
            return View();
        }

        // GET: ProductoController/Edit/5
        public ActionResult Fight(int id)
        {
            var torneoBuscado = service.buscarTorneos(id);
            ViewBag.Equipos = service.FiltroEquipos(torneoBuscado.Categoria);
            return View(torneoBuscado);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Fight(Torneo torneo,int Equipo1, int Equipo2)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(Equipo1 == Equipo2)
                    {
                        throw new Exception("No se puede jugar contra si mismo");
                    }
                    var E1 = service.buscarEquiposId(Equipo1);
                    var E2 = service.buscarEquiposId(Equipo2);
                    torneo = service.AsignarGanador(torneo,E1, E2);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
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
