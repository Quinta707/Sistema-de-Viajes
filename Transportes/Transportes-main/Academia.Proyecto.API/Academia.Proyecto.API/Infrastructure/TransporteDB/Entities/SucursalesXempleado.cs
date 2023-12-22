using System;
using System.Collections.Generic;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;

public partial class SucursalesXempleado
{
    public int SucursalXempleadoId { get; set; }

    public int? EmpleadoId { get; set; }

    public int? SucursalId { get; set; }

    public decimal? Kilometros { get; set; }

    public bool? Estado { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public DateTime? FechaModicicacion { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual Sucursale? Sucursal { get; set; }

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }

    public virtual ICollection<ViajesDetalle> ViajesDetalles { get; set; } = new List<ViajesDetalle>();
}
