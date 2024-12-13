using Microsoft.AspNetCore.Mvc;
using Practica3PrograAvW_WEB.Models;
using System.Text.Json;

namespace Practica3PrograAvW_WEB.Controllers
{
    public class PagoController : Controller
    {
        private readonly IHttpClientFactory _http;
        private readonly IConfiguration _conf;

        public PagoController(IHttpClientFactory http, IConfiguration conf)
        {
            _http = http;
            _conf = conf;
        }

        [HttpGet]
        public IActionResult RealizarPago()
        {
            using(var client = _http.CreateClient())
            {
                var url = _conf.GetSection("Variables:UrlApi").Value + "Producto/ConsultarProductosPendientes";
                var response = client.GetAsync(url).Result;
                var result = response.Content.ReadFromJsonAsync<Respuesta>().Result;

                if (result != null && result.Codigo == 0)
                {
                    var productosPendientes = JsonSerializer.Deserialize<List<Producto>>((JsonElement)result.Contenido!);
                    // Retornamos a la vista RealizarPago con los productos obtenidos
                    return View(productosPendientes);
                }
                else
                {
                    // Si no hay productos, se retorna una lista vacía
                    return View(new List<Producto>());
                }
            }
        }

    }
}
