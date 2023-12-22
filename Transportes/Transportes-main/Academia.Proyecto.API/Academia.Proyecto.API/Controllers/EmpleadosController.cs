using Academia.Proyecto.API._Features.Empleados;
using Academia.Proyecto.API._Features.Empleados.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadosService _empleadosService;

        public EmpleadosController(EmpleadosService empleadosService)
        {
            _empleadosService = empleadosService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _empleadosService.ListarEmpleados();
            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Insert(EmpleadosDto empleadosDto)
        {
            var respuesta = _empleadosService.InsertarEmpleados(empleadosDto);
            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public IActionResult Editar(EmpleadosDto empleadosDto)
        {
            var respuesta = _empleadosService.EditarEmpleados(empleadosDto);
            return Ok(respuesta);
        }

        [HttpPut("Desactivar")]
        public IActionResult DesactivarEmpleado(EmpleadosDto empleadosDto)
        {
            var respuesta = _empleadosService.DesactivarEmpleado(empleadosDto);
            return Ok(respuesta);
        }
    }
}
