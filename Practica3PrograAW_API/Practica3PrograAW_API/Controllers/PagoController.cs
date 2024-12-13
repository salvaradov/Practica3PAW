using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Practica3PrograAW_API.Models;

namespace Practica3PrograAW_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : Controller
    {
        private readonly IConfiguration _conf;

        public PagoController(IConfiguration conf)
        {
            _conf = conf;
        }

        
    }
}
