﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaDeViajes.Entities
{
    public partial class tbEmpleados
    {
        public int empl_Id { get; set; }
        public string empl_Nombres { get; set; }
        public string empl_Apellidos { get; set; }
        public string empl_DNI { get; set; }
        public int eciv_Id { get; set; }
        public string empl_Sexo { get; set; }
        public DateTime empl_FechaNacimiento { get; set; }
        public string empl_Telefono { get; set; }
        public string empl_DireccionExacta { get; set; }
        public int carg_Id { get; set; }
        public int usua_UsuarioCreacion { get; set; }
        public DateTime empl_FechaCreacion { get; set; }
        public int? usua_UsuarioModificacion { get; set; }
        public DateTime? empl_FechaModificacion { get; set; }
        public bool? empl_Estado { get; set; }

        public virtual tbCargos carg { get; set; }
        public virtual tbEstadosCiviles eciv { get; set; }
        public virtual tbUsuarios usua_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios usua_UsuarioModificacionNavigation { get; set; }
    }
}