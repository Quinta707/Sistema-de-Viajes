using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.ViajesMap
{
    public class ViajesMap : IEntityTypeConfiguration<Viaje>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Viaje> builder) {
            builder.ToTable(name: "Viajes");
            builder.HasKey(e => e.ViajeId).HasName("PK_Viajes_ViajeID");

            builder.Property(e => e.ViajeId).HasColumnName("ViajeID");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModicicacion).HasColumnType("datetime");
            builder.Property(e => e.Estado).HasDefaultValue(true);
            builder.Property(e => e.FechaViaje).HasColumnType("datetime");
            builder.Property(e => e.TransportistaId).HasColumnName("TransportistaID");
            builder.Property(e => e.UsuarioCreacionId).HasColumnName("UsuarioCreacionID");
            builder.Property(e => e.UsuarioModificacionId).HasColumnName("UsuarioModificacionID");

            builder.HasOne(d => d.Transportista).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.TransportistaId)
                .HasConstraintName("FK_Viajes_TransportistaID_Transportistas_TransportistaID");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.ViajeUsuarioCreacions)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_Viajes_UsuarioCreacionID_Usuarios_UsuarioCreacionID");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.ViajeUsuarioModificacions)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_Viajes_UsuarioModificacionID_Usuarios_UsuarioCModificacionID");
        }
    }
}
