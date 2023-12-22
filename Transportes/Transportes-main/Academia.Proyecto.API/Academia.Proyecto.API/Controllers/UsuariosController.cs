using Academia.Proyecto.API._Features.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosService _usuariosService;

        public UsuariosController(UsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _usuariosService.ListarUsuarios();
            return Ok(respuesta);
        }
    }
}
