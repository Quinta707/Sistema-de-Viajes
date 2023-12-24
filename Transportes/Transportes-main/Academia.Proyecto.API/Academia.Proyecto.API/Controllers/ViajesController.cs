using Academia.Proyecto.API._Features.Viajes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private readonly ViajesService _viajeservice;

        public ViajesController(ViajesService viajeservice)
        {
            _viajeservice = viajeservice;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _viajeservice.ListarViajes();
            return Ok(respuesta);
        }

        [HttpGet("ListarPorTransportista")]
        public IActionResult ListadoPorTransportista(int? TransportistaID)
        {
            var respuesta = _viajeservice.ListarViajesPorTransportista(TransportistaID);
            return Ok(respuesta);
        }
    }
}
