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
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(ILogger<ProductoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{idUsuario}")]
        public IEnumerable<Producto> GetAllProductos(int idUsuario)
        {
            return ADO_Producto.GetProductos(idUsuario);
        }

        [HttpPut]
        public void PutProductos(Producto producto)
        {
            
             ADO_Producto.ModificarProductos(producto);
        }

        [HttpPost]
        public void PostProducto(Producto producto)
        {
            ADO_Producto.InsertProducto(producto);
        }

        [HttpDelete("{idProducto}")]
        public void DeleteProductos(int idProducto)
        {
            ADO_Producto.EliminarProducto(idProducto);
        }
    }
}
