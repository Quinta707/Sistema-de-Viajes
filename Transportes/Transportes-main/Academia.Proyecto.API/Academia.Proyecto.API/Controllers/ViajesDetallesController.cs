using Academia.Proyecto.API._Features.ViajesDetalles;
using Academia.Proyecto.API._Features.ViajesDetalles.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesDetallesController : ControllerBase
    {
        private readonly ViajesDetallesService _viajesDetallesService;

        public ViajesDetallesController(ViajesDetallesService viajesDetallesService)
        {
            _viajesDetallesService = viajesDetallesService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _viajesDetallesService.ListarViajeDetalle();
            return Ok(respuesta);
        }

        [HttpGet("DetallesPorViaje")]
        public IActionResult ViajePorDetalle(int? ViajeID)
        {
            var respuesta = _viajesDetallesService.ListarPorViaje(ViajeID);
            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Insert(ViajesDetallesDto viajesDetallesDto)
        {
            var respuesta = _viajesDetallesService.InsertarViajesDetalles(viajesDetallesDto);
            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public IActionResult Editar(ViajesDetallesDto viajesDetallesDto)
        {
            var respuesta = _viajesDetallesService.EditarViajesDetalles(viajesDetallesDto);
            return Ok(respuesta);
        }

        [HttpPut("Desactivar")]
        public IActionResult Desactivar(ViajesDetallesDto viajesDetallesDto)
        {
            var respuesta = _viajesDetallesService.Desactivar(viajesDetallesDto);
            return Ok(respuesta);
        }

        [HttpPut("Activar")]
        public IActionResult Activar(ViajesDetallesDto viajesDetallesDto)
        {
            var respuesta = _viajesDetallesService.Activar(viajesDetallesDto);
            return Ok(respuesta);
        }
    }
}
