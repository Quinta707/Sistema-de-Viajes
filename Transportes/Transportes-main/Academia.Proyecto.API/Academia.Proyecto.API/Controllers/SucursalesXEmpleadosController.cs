using Academia.Proyecto.API._Features.SucursalesXEmpleados;
using Academia.Proyecto.API._Features.SucursalesXEmpleados.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesXEmpleadosController : ControllerBase
    {
        private readonly SucursalesXEmpleadoService _sucursalesXEmpleadosService;

        public SucursalesXEmpleadosController(SucursalesXEmpleadoService sucursalesXEmpleadosService)
        {
            _sucursalesXEmpleadosService = sucursalesXEmpleadosService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _sucursalesXEmpleadosService.ListarSucursalXEmpleado();
            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(SucursalesXEmpleadoDto sucursalesXEmpleadoDto)
        {
            var respuesta = _sucursalesXEmpleadosService.InsertarSucursalesXEmpleados(sucursalesXEmpleadoDto);
            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public IActionResult Editar(SucursalesXEmpleadoDto sucursalesXEmpleadoDto)
        {
            var respuesta = _sucursalesXEmpleadosService.EditarSucursalesXEmpleados(sucursalesXEmpleadoDto);
            return Ok(respuesta);
        }

        [HttpPut("Desactivar")]
        public IActionResult Desactivar(SucursalesXEmpleadoDto sucursalesXEmpleadoDto)
        {
            var respuesta = _sucursalesXEmpleadosService.DesactivarSucursalesXEmpleado(sucursalesXEmpleadoDto);
            return Ok(respuesta);
        }
    }
}
