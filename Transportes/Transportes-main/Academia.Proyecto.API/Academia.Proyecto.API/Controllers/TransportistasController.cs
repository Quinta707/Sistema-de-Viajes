using Academia.Proyecto.API._Features.Transportistas;
using Academia.Proyecto.API._Features.Transportistas.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransportistasController : ControllerBase
    {
        private readonly TransportistasService _transportistasService;

        public TransportistasController(TransportistasService transportistasService)
        {
            _transportistasService = transportistasService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _transportistasService.ListarTransportista();
            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(TransportistasDto transportista)
        {
            var respuesta = _transportistasService.InsertarTransportistas(transportista);

            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public IActionResult Editar(TransportistasDto transportista)
        {
            var respuesta = _transportistasService.EditarTransportistas(transportista);

            return Ok(respuesta);
        }

        [HttpPut("Desactivar")]
        public IActionResult Desactivar(TransportistasDto transportista)
        {
            var respuesta = _transportistasService.DesactivarTransportista(transportista);

            return Ok(respuesta);
        }

    }
}
