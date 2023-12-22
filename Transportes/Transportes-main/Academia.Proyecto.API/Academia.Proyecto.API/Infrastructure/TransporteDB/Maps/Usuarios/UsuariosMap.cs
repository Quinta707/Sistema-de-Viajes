using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.Usuarios
{
    public class UsuariosMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.UsuarioId).HasName("PK_Usuarios_UsuarioID");

            builder.HasIndex(e => e.EmpleadoId, "UQ__Usuarios__958BE6F10869C7C8").IsUnique();

            builder.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            builder.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            builder.Property(e => e.Estado).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModicicacion).HasColumnType("datetime");
            builder.Property(e => e.Usuario1)
                .HasMaxLength(100)
                .HasColumnName("Usuario");
            builder.Property(e => e.UsuarioCreacionId).HasColumnName("UsuarioCreacionID");
            builder.Property(e => e.UsuarioModificacionId).HasColumnName("UsuarioModificacionID");

            builder.HasOne(d => d.Empleado).WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(d => d.EmpleadoId)
                .HasConstraintName("FK_Usuarios_EmpleadoID_Empleados_EmpleadoID");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.InverseUsuarioCreacion)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_Usuarios_UsuarioCreacionID");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.InverseUsuarioModificacion)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_Usuarios_UsuarioCModificacionID");
        }
    }
}
