using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoFinal_JoanDamia.ADO.NET;
using ProyectoFinal_JoanDamia.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_JoanDamia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly ILogger<ProductoVendido> _logger;

        public VentaController(ILogger<ProductoVendido> logger)
        {
            _logger = logger;
        }

        [HttpGet("{idUsuario}")]
        public IEnumerable<Venta> GetVentas(int idUsuario)
        {
            return ADO_Venta.GetVentas(idUsuario);
        }

        [HttpPost("{idUsuario}")]
        public void PostVenta(List<Producto> productos, int idUsuario)
        {
            ADO_Venta.InsertVenta(productos, idUsuario);
        }

        [HttpDelete("{idVenta}")]
        public void DeleteProductos(int idVenta)
        {
            ADO_Venta.EliminarVenta(idVenta);
        }
    }
}
