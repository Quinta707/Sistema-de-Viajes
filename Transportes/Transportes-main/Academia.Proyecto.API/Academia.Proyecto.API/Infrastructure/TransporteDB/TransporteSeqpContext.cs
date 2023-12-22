using System;
using System.Collections.Generic;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.Empleados;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.EstadosCiviles;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.Sucursal;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.SucursalesXEmpleado;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.Transportistas;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.Usuarios;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.ViajeDetalles;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.ViajesMap;
using Microsoft.EntityFrameworkCore;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB;

public partial class TransporteSeqpContext : DbContext
{
    public TransporteSeqpContext(DbContextOptions<TransporteSeqpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EstadosCivile> EstadosCiviles { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    public virtual DbSet<SucursalesXempleado> SucursalesXempleados { get; set; }

    public virtual DbSet<Transportista> Transportistas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    public virtual DbSet<ViajesDetalle> ViajesDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmpleadosMap());
        modelBuilder.ApplyConfiguration(new EstadosCivilesMap());
        modelBuilder.ApplyConfiguration(new SucursalMap());
        modelBuilder.ApplyConfiguration(new SucursalesXEmpleadoMap());
        modelBuilder.ApplyConfiguration(new TransportistasMap());
        modelBuilder.ApplyConfiguration(new UsuariosMap());
        modelBuilder.ApplyConfiguration(new ViajesMap());
        modelBuilder.ApplyConfiguration(new ViajeDetalleMap());

    }

}
