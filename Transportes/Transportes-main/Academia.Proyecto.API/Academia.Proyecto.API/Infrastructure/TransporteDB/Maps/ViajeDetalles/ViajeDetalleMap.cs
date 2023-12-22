using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.ViajeDetalles
{
    public class ViajeDetalleMap : IEntityTypeConfiguration<ViajesDetalle>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ViajesDetalle> builder)
        {
            builder.HasKey(e => e.ViajeDetalleId).HasName("PK_ViajesDetalle_ViajeDetalleID");
            builder.ToTable("ViajesDetalle");

            builder.Property(e => e.ViajeDetalleId).HasColumnName("ViajeDetalleID");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModicicacion).HasColumnType("datetime");
            builder.Property(e => e.Kilometros).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.Estado).HasDefaultValue(true);
            builder.Property(e => e.SucursalXempleadoId).HasColumnName("SucursalXEmpleadoID");
            builder.Property(e => e.UsuarioCreacionId).HasColumnName("UsuarioCreacionID");
            builder.Property(e => e.UsuarioModificacionId).HasColumnName("UsuarioModificacionID");
            builder.Property(e => e.ViajeId).HasColumnName("ViajeID");

            builder.HasOne(d => d.SucursalXempleado).WithMany(p => p.ViajesDetalles)
                .HasForeignKey(d => d.SucursalXempleadoId)
                .HasConstraintName("FK_ViajesDetalle_SucursalXEmpleadoID_SucursalesXEmpleados_SucursalXEmpleadoID");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.ViajesDetalleUsuarioCreacions)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_ViajesDetalle_UsuarioCreacionID_Usuarios_UsuarioCreacionID");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.ViajesDetalleUsuarioModificacions)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_ViajesDetalle_UsuarioModificacionID_Usuarios_UsuarioCModificacionID");

            builder.HasOne(d => d.Viaje).WithMany(p => p.ViajesDetalles)
                .HasForeignKey(d => d.ViajeId)
                .HasConstraintName("FK_ViajesDetalle_ViajeID_Viajes_ViajeID");
        }
    }
}
