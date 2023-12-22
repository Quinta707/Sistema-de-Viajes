namespace Academia.Proyecto.API._Features.Usuarios.Dtos
{
    public class UsuariosDto
    {
        public int UsuarioId { get; set; }

        public int? EmpleadoId { get; set; }

        public string? EmpleadoNombre { get; set; }

        public string? EmpleadoApellido { get; set; }

        public string? Usuario1 { get; set; }

        public string? Clave { get; set; }

        public bool? Estado { get; set; }

        public int? UsuarioCreacionId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModificacionId { get; set; }

        public DateTime? FechaModicicacion { get; set; }
    }
}
