using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Practica2API.Entidades;
using ProyectoApi_Jueves.Entidades;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Practica2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController(IConfiguration _configuration) : ControllerBase
    {

        [AllowAnonymous]
        [Route("RegistrarVendedor")]
        [HttpPost]
        public IActionResult RegistrarUsuario(Vendedor entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                Respuesta respuesta = new Respuesta();

                var result = db.Execute("RegistrarVendedor",
                    new { entidad.Cedula, entidad.Nombre, entidad.Correo },
                    commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "Vendedor ya registrado.";
                }

                return Ok(respuesta);
            }
        }


        [AllowAnonymous]
        [Route("ObtenerVehiculos")]
        [HttpGet]
        public IActionResult ObtenerVehiculos()
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                Respuesta respuesta = new Respuesta();

                var result = db.Execute("ObtenerVehiculos",
                    commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "Vendedor ya registrado.";
                }

                return Ok(result);
            }
        }


        //[AllowAnonymous]
        //[Route("ConsultarVendedores")]
        //[HttpGet]
        //public IActionResult ConsultarVendedores()
        //{
        //    using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        Respuesta respuesta = new Respuesta();

        //        var query = "SELECT Nombre FROM Vendedores";

        //        var result = (IActionResult)db.QueryAsync<Vendedor>(query);

        //        return result;

        //    }

        [AllowAnonymous]
        [Route("ConsultarVendedores")]
        [HttpGet]
        public IActionResult ConsultarVendedores()
        {

            var query = "SELECT IdVendedor, Nombre FROM Vendedores";
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var vendedores = db.Query<Vendedor>(query).ToList();
                return Ok(vendedores);
            }
        }

    }
}
