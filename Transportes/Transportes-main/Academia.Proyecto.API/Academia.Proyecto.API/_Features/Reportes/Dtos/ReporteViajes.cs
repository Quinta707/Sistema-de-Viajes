using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;

namespace Academia.Proyecto.API._Features.Reportes.Dtos
{
    public class ReporteViajes
    {
        public int ViajeId { get; set; }

        public int? EmpleadoId { get; set; }

        public string? EmpleadoNombre { get; set; }

        public string? EmpleadoApellido { get; set; }

        public int? CantidadViajes { get; set; }

    }
}
