using Microsoft.Extensions.Configuration;
using Practica2WEB.Entidades;
using Practica2WEB.Services;
using static System.Net.WebRequestMethods;

namespace Practica2WEB.Models
{
    public class VehiculoModel(HttpClient _http, IConfiguration _configuration) : IVehiculoModel
    {
        public Respuesta? RegistrarVehiculo(Vehiculo entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Vehiculo/RegistrarVehiculo";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }
    }
}
