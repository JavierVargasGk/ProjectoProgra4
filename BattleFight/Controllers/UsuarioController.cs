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
            var model = service.mostrarUsuario();
            return View(model);
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
                    if (ViewBag.NombreUsuario == null)
                    {
                        return RedirectToAction("LogIn", "Usuario");
                    } 
                    return RedirectToAction("Index", "Usuario");
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
            var model = service.buscarUsuario(id);
            return View(model);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario, string confirmacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (usuario.Contrasenna != confirmacion)
                    {
                        throw new Exception("Contraseñas no coinciden");
                    }
                        service.actualizarUsuario(usuario);
                        return RedirectToAction(nameof(Index));
                    }                   
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var usuarioBuscado= service.buscarUsuario(id);
                service.eliminarUsuario(usuarioBuscado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
