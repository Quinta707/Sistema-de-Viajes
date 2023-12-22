using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.Transportistas
{
    public class TransportistasMap : IEntityTypeConfiguration<Transportista>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transportista> builder)
        {
            builder.HasKey(e => e.TransportistaId).HasName("PK_Transportistas_TransportistaID");

            builder.HasIndex(e => e.Identidad, "UQ__Transpor__5C06DCB48E7474FD").IsUnique();

            builder.Property(e => e.TransportistaId).HasColumnName("TransportistaID");
            builder.Property(e => e.Apellido).HasMaxLength(100);
            builder.Property(e => e.EstadoCivilId).HasColumnName("EstadoCivilID");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModicicacion).HasColumnType("datetime");
            builder.Property(e => e.Identidad).HasMaxLength(50);
            builder.Property(e => e.Nombre).HasMaxLength(100);
            builder.Property(e => e.TarifaPorKm)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TarifaPorKM");
            builder.Property(e => e.Telefono).HasMaxLength(50);
            builder.Property(e => e.Estado).HasDefaultValue(true);
            builder.Property(e => e.UsuarioCreacionId).HasColumnName("UsuarioCreacionID");
            builder.Property(e => e.UsuarioModificacionId).HasColumnName("UsuarioModificacionID");

            builder.HasOne(d => d.EstadoCivil).WithMany(p => p.Transportista)
                .HasForeignKey(d => d.EstadoCivilId)
                .HasConstraintName("FK_Transportistas_EstadoCivilID_EstadosCiviles_EstadoCivilID");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.TransportistaUsuarioCreacions)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_Transportistas_UsuarioCreacionID_Usuarios_UsuarioCreacionID");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.TransportistaUsuarioModificacions)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_Transportistas_UsuarioModificacionID_Usuarios_UsuarioCModificacionID");
        }
    }
}
