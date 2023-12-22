using System;
using System.Collections.Generic;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public int? EmpleadoId { get; set; }

    public string? Usuario1 { get; set; }

    public string? Clave { get; set; }

    public bool? Estado { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public DateTime? FechaModicicacion { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual ICollection<Empleado> EmpleadoUsuarioCreacions { get; set; } = new List<Empleado>();

    public virtual ICollection<Empleado> EmpleadoUsuarioModificacions { get; set; } = new List<Empleado>();

    public virtual ICollection<EstadosCivile> EstadosCivileUsuarioCreacions { get; set; } = new List<EstadosCivile>();

    public virtual ICollection<EstadosCivile> EstadosCivileUsuarioModificacions { get; set; } = new List<EstadosCivile>();

    public virtual ICollection<Usuario> InverseUsuarioCreacion { get; set; } = new List<Usuario>();

    public virtual ICollection<Usuario> InverseUsuarioModificacion { get; set; } = new List<Usuario>();

    public virtual ICollection<Sucursale> SucursaleUsuarioCreacions { get; set; } = new List<Sucursale>();

    public virtual ICollection<Sucursale> SucursaleUsuarioModificacions { get; set; } = new List<Sucursale>();

    public virtual ICollection<SucursalesXempleado> SucursalesXempleadoUsuarioCreacions { get; set; } = new List<SucursalesXempleado>();

    public virtual ICollection<SucursalesXempleado> SucursalesXempleadoUsuarioModificacions { get; set; } = new List<SucursalesXempleado>();

    public virtual ICollection<Transportista> TransportistaUsuarioCreacions { get; set; } = new List<Transportista>();

    public virtual ICollection<Transportista> TransportistaUsuarioModificacions { get; set; } = new List<Transportista>();

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }

    public virtual ICollection<Viaje> ViajeUsuarioCreacions { get; set; } = new List<Viaje>();

    public virtual ICollection<Viaje> ViajeUsuarioModificacions { get; set; } = new List<Viaje>();

    public virtual ICollection<ViajesDetalle> ViajesDetalleUsuarioCreacions { get; set; } = new List<ViajesDetalle>();

    public virtual ICollection<ViajesDetalle> ViajesDetalleUsuarioModificacions { get; set; } = new List<ViajesDetalle>();
}
