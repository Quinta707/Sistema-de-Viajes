namespace Academia.Proyecto.API._Features.EstadosCiviles.Dtos
{
    public class EstadosCivilesDto
    {
        public int EstadoCivilId { get; set; }

        public string? Descripcion { get; set; }

        public bool? Estado { get; set; }

        public int? UsuarioCreacionId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModificacionId { get; set; }

        public DateTime? FechaModicicacion { get; set; }
    }
}
