using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.EstadosCiviles
{
    public class EstadosCivilesMap : IEntityTypeConfiguration<EstadosCivile>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EstadosCivile> builder)
        {
            builder.HasKey(e => e.EstadoCivilId).HasName("PK_EstadosCiviles_EstadoCivilID");

            builder.Property(e => e.EstadoCivilId).HasColumnName("EstadoCivilID");
            builder.Property(e => e.Descripcion).HasMaxLength(100);
            builder.Property(e => e.Estado).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModicicacion).HasColumnType("datetime");
            builder.Property(e => e.UsuarioCreacionId).HasColumnName("UsuarioCreacionID");
            builder.Property(e => e.UsuarioModificacionId).HasColumnName("UsuarioModificacionID");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.EstadosCivileUsuarioCreacions)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_EstadosCiviles_UsuarioCreacionID_Usuarios_UsuarioCreacionID");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.EstadosCivileUsuarioModificacions)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_EstadosCiviles_UsuarioModificacionID_Usuarios_UsuarioCModificacionID");
        }
    }
}
