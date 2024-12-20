using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BattleFight.Service;
using BattleFight.Models;

namespace BattleFight.Controllers
{
    public class EquipoController : Controller
    {

        private Services service;


        public EquipoController()
        {
            this.service = new Services();
        }
        // GET: ProductoController
        public ActionResult Index()
        {
            var model = service.mostrarEquipos();
            return View(model);
        }

        // POST: ProductoController/Index
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(string EquipoBuscado)
        {
            var model = new List<Equipo>();
            if (EquipoBuscado != "")
            {
                model = service.FiltroEquipos(EquipoBuscado);
            }
            else {model = service.mostrarEquipos();}
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
        public ActionResult Create(Equipo equipo)
        {
            try
            {
                if (equipo != null)
                {
                    service.agregarEquipo(equipo);
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Equipo creado es nullo");
                }
            }
            catch(Exception e){throw new Exception(e.Message); }
            return View();
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            var equipoBuscado = service.buscarEquiposId(id);
            return View(equipoBuscado);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Equipo equipo)
        {
            try
            {
                if (equipo != null)
                {
                    service.actualizarEquipo(equipo);
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Equipo creado es nullo");
                    return View();
                }
            }
            catch(Exception e){throw new Exception(e.Message); }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var equipoBuscado = service.buscarEquiposId(id);
                service.eliminarEquipo(equipoBuscado);
                return RedirectToAction("Index");
            }

            catch (Exception) { }
            return View();
        }
    }
    }

