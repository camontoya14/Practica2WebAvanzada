using Microsoft.AspNetCore.Mvc;
using Practica2WEB.Entidades;
using Practica2WEB.Services;

namespace Practica2WEB.Controllers
{
    public class VendedorController(IVendedorModel _usuarioModel) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult RegistrarVendedor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarVendedor(Vendedor entidad)
        {
            var resp = _usuarioModel.RegistrarVendedor(entidad);

            if (resp?.Codigo == "00")
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.MsjPantallla = resp?.Mensaje;
                return View();
            }
        }

    }
}
