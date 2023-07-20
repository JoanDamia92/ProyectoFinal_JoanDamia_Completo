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
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<ProductoVendido> _logger;

        public UsuarioController(ILogger<ProductoVendido> logger)
        {
            _logger = logger;
        }

        [HttpGet("{nombreUsuario}/{contraseña}")]
        public Usuario GetUsuarioByContraseña(string nombreUsuario, string contraseña)
        {
            var usuario = ADO_Usuario.GetUsuarioByPassword(nombreUsuario, contraseña);

            return usuario == null ? new Usuario() : usuario;
        }

        [HttpGet("{nombreUsuario}")]
        public Usuario GetUsuarioByNombre(string nombreUsuario)
        {
            var usuario = ADO_Usuario.GetUsuarioByUserName(nombreUsuario);

            return usuario == null ? new Usuario() : usuario;
        }

        [HttpPost]
        public void PostUsuario(Usuario usuario)
        {
            ADO_Usuario.InsertUsuario(usuario);
        }

        [HttpPut]
        public bool PutUsuario(Usuario usuario)
        {
            return ADO_Usuario.UpdateUsuario(usuario);
        }

        [HttpDelete("{idUsuario}")]
        public void DeleteUsuario(int idUsuario)
        {
            ADO_Usuario.EliminarUsuario(idUsuario);
        }
    }
}
