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
                    new { entidad.Cedula, entidad.NombreVendedor, entidad.Correo },
                    commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "Vendedor ya registrado.";
                }

                return Ok(respuesta);
            }
        }
    }
}
