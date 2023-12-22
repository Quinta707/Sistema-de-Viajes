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

        //[HttpPost("Insertar")]
        //public IActionResult Insert(ViajesDetallesDto viajesDetallesDto)
        //{
        //    var respuesta = _viajesDetallesService.InsertarViajesDetalles(viajesDetallesDto);
        //    return Ok(respuesta);
        //}
    }
}
