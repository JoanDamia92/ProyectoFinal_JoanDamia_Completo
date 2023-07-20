using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoFinal_JoanDamia.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_JoanDamia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NombreController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Proyecto Final CoderHouse : Joan Damia";
        }
    }
}
