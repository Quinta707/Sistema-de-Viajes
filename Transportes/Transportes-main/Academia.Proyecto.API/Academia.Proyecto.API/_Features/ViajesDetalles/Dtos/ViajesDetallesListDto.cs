namespace Academia.Proyecto.API._Features.ViajesDetalles.Dtos
{
    public class ViajesDetallesListDto
    {
        public int ViajeDetalleId { get; set; }

        public int? ViajeId { get; set; }

        public int? SucursalXempleadoId { get; set; }

        public decimal? Kilometros { get; set; }

        public bool? Estado { get; set; }

        public int? UsuarioCreacionId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModificacionId { get; set; }

        public DateTime? FechaModicicacion { get; set; }


        public int? SucursalId { get; set; }

        public string? SucursalNombre { get; set; }

        public int? EmpleadoId { get; set; }

        public string? EmpleadoNombre { get; set; }

        public string? EmpleadoApellido { get; set; }

    }
}
