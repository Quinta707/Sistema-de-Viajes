using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;

namespace Academia.Proyecto.API._Features.Sucursales.Dtos
{
    public class SucursalesDto
    {
        public int SucursalId { get; set; }

        public string? Nombre { get; set; }

        public bool? Estado { get; set; }

        public int? UsuarioCreacionId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModificacionId { get; set; }

        public DateTime? FechaModicicacion { get; set; }

    }
}
