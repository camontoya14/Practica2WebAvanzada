using Microsoft.AspNetCore.Mvc;
using Practica2WEB.Entidades;
using Practica2WEB.Models;
using Practica2WEB.Services;

namespace Practica2WEB.Controllers
{
    public class VehiculoController(IVehiculoModel _vehiculoModel, IVendedorModel _vendedorModel) : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult RegistrarVehiculo()
        {
            ViewBag.Vendedores = _vendedorModel.ConsultarVendedores();
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarVehiculo(Vehiculo entidad)
        {
            var resp = _vehiculoModel.RegistrarVehiculo(entidad);

            if (resp?.Codigo == "00")
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }
    }
}
