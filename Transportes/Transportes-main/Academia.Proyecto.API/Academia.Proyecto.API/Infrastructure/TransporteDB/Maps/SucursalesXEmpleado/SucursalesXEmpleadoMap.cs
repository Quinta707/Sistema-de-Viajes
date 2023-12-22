using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.SucursalesXEmpleado
{
    public class SucursalesXEmpleadoMap : IEntityTypeConfiguration<SucursalesXempleado>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SucursalesXempleado> builder)
        {
            builder.HasKey(e => e.SucursalXempleadoId).HasName("PK_SucursalesXEmpleados_SucursalXEmpleadoID");
            builder.ToTable("SucursalesXEmpleados");

            builder.Property(e => e.SucursalXempleadoId).HasColumnName("SucursalXEmpleadoID");
            builder.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModicicacion).HasColumnType("datetime");
            builder.Property(e => e.Kilometros).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.SucursalId).HasColumnName("SucursalID");
            builder.Property(e => e.Estado).HasDefaultValue(true);
            builder.Property(e => e.UsuarioCreacionId).HasColumnName("UsuarioCreacionID");
            builder.Property(e => e.UsuarioModificacionId).HasColumnName("UsuarioModificacionID");

            builder.HasOne(d => d.Empleado).WithMany(p => p.SucursalesXempleados)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_SucursalesXEmpleados_EmpleadoID_Empleados_EmpleadoID");

            builder.HasOne(d => d.Sucursal).WithMany(p => p.SucursalesXempleados)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK_SucursalesXEmpleados_SucursaleID_Sucursales_SucursaleID");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.SucursalesXempleadoUsuarioCreacions)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_SucursalesXEmpleados_UsuarioCreacionID_Usuarios_UsuarioCreacionID");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.SucursalesXempleadoUsuarioModificacions)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_SucursalesXEmpleados_UsuarioModificacionID_Usuarios_UsuarioCModificacionID");
        }
    }
}
