using System;
using System.Collections.Generic;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;

public partial class ViajesDetalle
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

    public virtual SucursalesXempleado? SucursalXempleado { get; set; }

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }

    public virtual Viaje? Viaje { get; set; }
}
