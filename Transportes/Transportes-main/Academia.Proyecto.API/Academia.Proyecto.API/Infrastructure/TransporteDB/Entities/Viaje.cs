using System;
using System.Collections.Generic;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;

public partial class Viaje
{
    public int ViajeId { get; set; }

    public int? TransportistaId { get; set; }

    public DateTime? FechaViaje { get; set; }

    public bool? Estado { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public DateTime? FechaModicicacion { get; set; }

    public virtual Transportista? Transportista { get; set; }

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }

    public virtual ICollection<ViajesDetalle> ViajesDetalles { get; set; } = new List<ViajesDetalle>();
}
