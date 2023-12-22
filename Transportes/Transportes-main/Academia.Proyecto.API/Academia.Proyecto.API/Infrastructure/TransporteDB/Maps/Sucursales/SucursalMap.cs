using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.Sucursal
{
    public class SucursalMap : IEntityTypeConfiguration<Sucursale>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Sucursale> builder)
        {
            builder.HasKey(e => e.SucursalId).HasName("PK_Sucursales_SucursalID");

            builder.Property(e => e.SucursalId).HasColumnName("SucursalID");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModicicacion).HasColumnType("datetime");
            builder.Property(e => e.Estado).HasDefaultValue(true);
            builder.Property(e => e.Nombre).HasMaxLength(100);
            builder.Property(e => e.UsuarioCreacionId).HasColumnName("UsuarioCreacionID");
            builder.Property(e => e.UsuarioModificacionId).HasColumnName("UsuarioModificacionID");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.SucursaleUsuarioCreacions)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_Sucursales_UsuarioCreacionID_Usuarios_UsuarioCreacionID");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.SucursaleUsuarioModificacions)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_Sucursales_UsuarioModificacionID_Usuarios_UsuarioCModificacionID");
        }
    }
}
