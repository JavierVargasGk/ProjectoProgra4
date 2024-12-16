using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BattleFight.Service;
using BattleFight.Models;

namespace BattleFight.Controllers
{
    public class UsuarioController : Controller
    {

        private Services service;


        public UsuarioController()
        {
            this.service = new Services();
        }
        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/login
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Usuario user)
        {
            try
            {
                var UsuarioLogueado = service.validarLogin(user.Alias, user.Contrasenna);
                HttpContext.Session.SetString("NombreUsuario", UsuarioLogueado.Nombre);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(Usuario usuario,string confirmacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (usuario.Contrasenna != confirmacion)
                    {
                        throw new Exception("Contraseñas no coinciden");
                    }
                    service.agregarUsuario(usuario);
                    return RedirectToAction("LogIn", "Usuario");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
            return View();
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
