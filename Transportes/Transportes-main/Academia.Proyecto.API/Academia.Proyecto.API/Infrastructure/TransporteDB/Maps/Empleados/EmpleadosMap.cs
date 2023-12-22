using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using Farsiman.Domain.Core.Standard.Common;
using IdentityModel;
using Microsoft.EntityFrameworkCore;

namespace Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.Empleados
{
    public class EmpleadosMap : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(e => e.EmpleadoId).HasName("PK_Empleados_EmpleadoID");

            builder.HasIndex(e => e.Identidad, "UQ__Empleado__5C06DCB45B7244A6").IsUnique();

            builder.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            builder.Property(e => e.Apellido).HasMaxLength(100);
            builder.Property(e => e.Estado).HasDefaultValue(true);
            builder.Property(e => e.EstadoCivilId).HasColumnName("EstadoCivilID");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModicicacion).HasColumnType("datetime");
            builder.Property(e => e.Identidad).HasMaxLength(50);
            builder.Property(e => e.Nombre).HasMaxLength(100);
            builder.Property(e => e.Telefono).HasMaxLength(50);
            builder.Property(e => e.UsuarioCreacionId).HasColumnName("UsuarioCreacionID");
            builder.Property(e => e.UsuarioModificacionId).HasColumnName("UsuarioModificacionID");

            builder.HasOne(d => d.EstadoCivil).WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.EstadoCivilId)
                    .HasConstraintName("FK_Empleados_EstadoCivilID_EstadosCiviles_EstadoCivilID");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.EmpleadoUsuarioCreacions)
                    .HasForeignKey(d => d.UsuarioCreacionId)
                    .HasConstraintName("FK_Empleados_UsuarioCreacionID_Usuarios_UsuarioCreacionID");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.EmpleadoUsuarioModificacions)
                    .HasForeignKey(d => d.UsuarioModificacionId)
                    .HasConstraintName("FK_Empleados_UsuarioModificacionID_Usuarios_UsuarioCModificacionID");
        }
    }
}
