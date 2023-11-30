﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaDeViajes.Entities
{
    public partial class tbUsuarios
    {
        public tbUsuarios()
        {
            tbCargosusua_UsuarioCreacionNavigation = new HashSet<tbCargos>();
            tbCargosusua_UsuarioModificacionNavigation = new HashSet<tbCargos>();
            tbDepartamentosusua_UsuarioCreacionNavigation = new HashSet<tbDepartamentos>();
            tbDepartamentosusua_UsuarioModificacionNavigation = new HashSet<tbDepartamentos>();
            tbEmpleadosusua_UsuarioCreacionNavigation = new HashSet<tbEmpleados>();
            tbEmpleadosusua_UsuarioModificacionNavigation = new HashSet<tbEmpleados>();
            tbEstadosCivilesusua_UsuarioCreacionNavigation = new HashSet<tbEstadosCiviles>();
            tbEstadosCivilesusua_UsuarioModificacionNavigation = new HashSet<tbEstadosCiviles>();
            tbMunicipiosusua_UsuarioCreacionNavigation = new HashSet<tbMunicipios>();
            tbMunicipiosusua_UsuarioModificacionNavigation = new HashSet<tbMunicipios>();
            tbPantallasusua_UsuarioCreacionNavigation = new HashSet<tbPantallas>();
            tbPantallasusua_UsuarioModificacionNavigation = new HashSet<tbPantallas>();
            tbRolesXPantallasusua_UsuarioCreacionNavigation = new HashSet<tbRolesXPantallas>();
            tbRolesXPantallasusua_UsuarioModificacionNavigation = new HashSet<tbRolesXPantallas>();
            tbRolesusua_UsuarioCreacionNavigation = new HashSet<tbRoles>();
            tbRolesusua_UsuarioModificacionNavigation = new HashSet<tbRoles>();
            tbSucursalesPorEmpleadosusua_UsuarioCreacionNavigation = new HashSet<tbSucursalesPorEmpleados>();
            tbSucursalesPorEmpleadosusua_UsuarioModificacionNavigation = new HashSet<tbSucursalesPorEmpleados>();
            tbSucursalesusua_UsuarioCreacionNavigation = new HashSet<tbSucursales>();
            tbSucursalesusua_UsuarioModificacionNavigation = new HashSet<tbSucursales>();
            tbTransportistausua_UsuarioCreacionNavigation = new HashSet<tbTransportista>();
            tbTransportistausua_UsuarioModificacionNavigation = new HashSet<tbTransportista>();
            tbViajesusua_UsuarioCreacionNavigation = new HashSet<tbViajes>();
            tbViajesusua_UsuarioModificacionNavigation = new HashSet<tbViajes>();
        }

        public int usua_Id { get; set; }
        public string usua_Nombre { get; set; }
        public string usua_Contrasenia { get; set; }
        public int empl_Id { get; set; }
        public int role_Id { get; set; }
        public bool usua_EsAdmin { get; set; }
        public int usua_UsuarioCreacion { get; set; }
        public DateTime usua_FechaCreacion { get; set; }
        public int? usua_UsuarioModificacion { get; set; }
        public DateTime? usua_FechaModificacion { get; set; }
        public bool? usua_Estado { get; set; }

        public virtual ICollection<tbCargos> tbCargosusua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbCargos> tbCargosusua_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbDepartamentos> tbDepartamentosusua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbDepartamentos> tbDepartamentosusua_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbEmpleados> tbEmpleadosusua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbEmpleados> tbEmpleadosusua_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbEstadosCiviles> tbEstadosCivilesusua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbEstadosCiviles> tbEstadosCivilesusua_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbMunicipios> tbMunicipiosusua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbMunicipios> tbMunicipiosusua_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbPantallas> tbPantallasusua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbPantallas> tbPantallasusua_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbRolesXPantallas> tbRolesXPantallasusua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbRolesXPantallas> tbRolesXPantallasusua_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbRoles> tbRolesusua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbRoles> tbRolesusua_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbSucursalesPorEmpleados> tbSucursalesPorEmpleadosusua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbSucursalesPorEmpleados> tbSucursalesPorEmpleadosusua_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbSucursales> tbSucursalesusua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbSucursales> tbSucursalesusua_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbTransportista> tbTransportistausua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbTransportista> tbTransportistausua_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbViajes> tbViajesusua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbViajes> tbViajesusua_UsuarioModificacionNavigation { get; set; }
    }
}