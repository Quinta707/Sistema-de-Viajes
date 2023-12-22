using Academia.Proyecto.API._Features.Sucursales;
using Academia.Proyecto.API._Features.Sucursales.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly SucursalesService _sucursalesService;

        public SucursalesController(SucursalesService sucursalesService)
        {
            _sucursalesService = sucursalesService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _sucursalesService.ListarSucursales();
            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(SucursalesDto sucursalesDto)
        {
            var respuesta = _sucursalesService.InsertarSucursales(sucursalesDto);
            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public IActionResult Editar(SucursalesDto sucursalesDto)
        {
            var respuesta = _sucursalesService.EditarSucursales(sucursalesDto);
            return Ok(respuesta);
        }

        [HttpPut("Desactivar")]
        public IActionResult Desactivar(SucursalesDto sucursalesDto)
        {
            var respuesta = _sucursalesService.DesactivarSucursales(sucursalesDto);
            return Ok(respuesta);
        }
    }
}
