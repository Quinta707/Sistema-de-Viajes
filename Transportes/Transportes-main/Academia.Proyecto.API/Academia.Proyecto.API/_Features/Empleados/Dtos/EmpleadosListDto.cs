using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;

namespace Academia.Proyecto.API._Features.Empleados.Dtos
{
    public class EmpleadosListDto
    {
        public int EmpleadoId { get; set; }

        public string? Nombre { get; set; }

        public bool? Estado { get; set; }

        public string? Apellido { get; set; }

        public string? Identidad { get; set; }

        public string? Telefono { get; set; }

        public int? EstadoCivilId { get; set; }

        public string? EstadoCivilDescripcion { get; set; }

        public int? UsuarioCreacionId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModificacionId { get; set; }

        public DateTime? FechaModicicacion { get; set; }


    }
}
