using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using Dapper;
using Microsoft.Data.SqlClient;
using Practica3PrograAW_API.Models;


namespace Practica3PrograAW_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly IConfiguration _conf;
        private readonly IHostEnvironment _env;

        public ProductoController(IConfiguration conf, IHostEnvironment env)
        {
            _conf = conf;
            _env = env;
        }

        [HttpGet]
        [Route("ConsultarProductos")]
        public IActionResult ConsultarProductos()
        {
            using (var context = new SqlConnection(_conf.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var respuesta = new Respuesta();
                var result = context.Query<Producto>("ConsultarProductos", new { });

                if (result.Any())
                {
                    respuesta.Codigo = 0;
                    respuesta.Contenido = result;
                }
                else
                {
                    respuesta.Codigo = -1;
                    respuesta.Mensaje = "No hay productos registrados";
                }
                return Ok(respuesta);
            }
        }


        [HttpGet]
        [Route("ConsultarProductosPendientes")]
        public IActionResult ConsultarProductosPendientes()
        {
            using (var context = new SqlConnection(_conf.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var respuesta = new Respuesta();
                var result = context.Query<Producto>("ConsultarProductosPendientes", new { });

                if (result.Any())
                {
                    respuesta.Codigo = 0;
                    respuesta.Contenido = result;
                }
                else
                {
                    respuesta.Codigo = -1;
                    respuesta.Mensaje = "No hay productos pendientes";
                }
                return Ok(respuesta);
            }

        }
    }
}
