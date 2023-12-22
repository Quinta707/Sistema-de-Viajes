using System;
using System.Collections.Generic;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;

public partial class EstadosCivile
{
    public int EstadoCivilId { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public DateTime? FechaModicicacion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Transportista> Transportista { get; set; } = new List<Transportista>();

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }
}
