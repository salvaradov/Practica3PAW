using Microsoft.AspNetCore.Mvc;
using Practica3PrograAvW_WEB.Models;
using System.Text.Json;

namespace Practica3PrograAvW_WEB.Controllers
{
    public class ProductoController : Controller
    {

        private readonly IHttpClientFactory _http;
        private readonly IConfiguration _conf;

        public ProductoController(IHttpClientFactory http, IConfiguration conf)
        {
            _http = http;
            _conf = conf;
        }

        [HttpGet]
        public IActionResult ConsultarProductos()
        {
            using(var client = _http.CreateClient())
            {
                var url = _conf.GetSection("Variables:UrlApi").Value + "Producto/ConsultarProductos";

                var response = client.GetAsync(url).Result;
                var result = response.Content.ReadFromJsonAsync<Respuesta>().Result;
                
                if(result != null && result.Codigo == 0)
                {
                    var datosContenido = JsonSerializer.Deserialize<List<Producto>>((JsonElement)result.Contenido!);
                    var productosOrdenados = datosContenido.OrderBy(p => p.Estado == "Pendiente" ? 0:1)
                        .ThenBy(p=>p.Estado).ToList();
                    
                    return View(productosOrdenados);
                }

                return View(new List<Producto>());
            
            }
        }


        [HttpGet]
        public IActionResult ConsultarProductosPendientes()
        {
            using (var client = _http.CreateClient())
            {
                var url = _conf.GetSection("Variables:UrlApi").Value + "Producto/ConsultarProductosPendientes";

                var response = client.GetAsync(url).Result;
                var result = response.Content.ReadFromJsonAsync<Respuesta>().Result;

                if (result != null && result.Codigo == 0)
                {
                    var datosContenido = JsonSerializer.Deserialize<List<Producto>>((JsonElement)result.Contenido!);
                    return View(datosContenido);
                }

                return View(new List<Producto>());

            }
        }

    }
}
