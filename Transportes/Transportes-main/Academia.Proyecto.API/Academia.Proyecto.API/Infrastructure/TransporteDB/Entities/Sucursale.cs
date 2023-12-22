using System;
using System.Collections.Generic;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;

public partial class Sucursale
{
    public int SucursalId { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public DateTime? FechaModicicacion { get; set; }

    public virtual ICollection<SucursalesXempleado> SucursalesXempleados { get; set; } = new List<SucursalesXempleado>();

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }
}
