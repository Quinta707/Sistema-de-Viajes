using System;
using System.Collections.Generic;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public bool? Estado { get; set; }

    public string? Identidad { get; set; }

    public string? Telefono { get; set; }

    public int? EstadoCivilId { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public DateTime? FechaModicicacion { get; set; }

    public virtual EstadosCivile? EstadoCivil { get; set; }

    public virtual ICollection<SucursalesXempleado> SucursalesXempleados { get; set; } = new List<SucursalesXempleado>();

    public virtual Usuario? Usuario { get; set; }

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }
}
