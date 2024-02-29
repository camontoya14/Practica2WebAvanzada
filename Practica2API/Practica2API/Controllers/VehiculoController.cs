using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Practica2API.Entidades;
using ProyectoApi_Jueves.Entidades;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Practica2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController(IConfiguration _configuration) : ControllerBase
    {
        [AllowAnonymous]
        [Route("RegistrarVehiculo")]
        [HttpPost]
        public IActionResult RegistrarVehiculo(Vehiculo entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                Respuesta respuesta = new Respuesta();

                var result = db.Execute("RegistrarVehiculo",
                    new { entidad.Marca, entidad.Modelo, entidad.Color, entidad.Precio ,entidad.IdVendedor},
                    commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "No se pueden registrar mas de dos vehiculos de la misma marca.";
                }

                return Ok(respuesta);
            }
        }
    }
}
