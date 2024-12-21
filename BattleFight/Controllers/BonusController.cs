using BattleFight.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BattleFight.Controllers
{
    public class BonusController : Controller
    {
        private readonly ILogger<BonusController> _logger;

        public BonusController(ILogger<BonusController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.NombreUsuario = user;
            return View();
        }

        public IActionResult AcercaDe()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
