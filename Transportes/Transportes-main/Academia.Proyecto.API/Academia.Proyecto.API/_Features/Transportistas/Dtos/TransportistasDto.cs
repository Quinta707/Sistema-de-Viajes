namespace Academia.Proyecto.API._Features.Transportistas.Dtos
{
    public class TransportistasDto
    {
        public int TransportistaId { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Identidad { get; set; }

        public string? Telefono { get; set; }

        public bool? Estado { get; set; }

        public int? EstadoCivilId { get; set; }

        public string? EstadoCivilDescripcion { get; set; }

        public decimal? TarifaPorKm { get; set; }

        public int? UsuarioCreacionId { get; set; }

        public string? UsuarioCreacionNombre { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModificacionId { get; set; }

        public string? UsuarioModificacionNombre { get; set; }

        public DateTime? FechaModicicacion { get; set; }
    }
}
