using Microsoft.Extensions.Configuration;
using Practica2WEB.Entidades;
using Practica2WEB.Services;
using static System.Net.WebRequestMethods;

namespace Practica2WEB.Models
{
    public class VendedorModel(HttpClient _http, IConfiguration _configuration) : IVendedorModel
    {
        public Respuesta? RegistrarVendedor(Vendedor entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Vendedor/RegistrarVendedor";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }

    }
}
