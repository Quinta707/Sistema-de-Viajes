using Academia.Proyecto.API._Features.Reportes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        ReportesService _reportesService;

        public ReportesController(ReportesService reportesService)
        {
            _reportesService = reportesService;
        }

        [HttpGet("ReporteViajesPorEmpleados")]
        public IActionResult ReporteEmpleados()
        {
            var respuesta = _reportesService.ReporteViajesEmpleados();
            return Ok(respuesta);
        }

        [HttpGet("ReporteViajesTransportistas")]
        public IActionResult ReporteTransportistas(DateTime? FechaInicio, DateTime? FechaFin, int? TransportistaID)
        {
            var respuesta = _reportesService.ReporteViajesTransportistas(FechaInicio, FechaFin, TransportistaID);
            return Ok(respuesta);
        }
    }
}
