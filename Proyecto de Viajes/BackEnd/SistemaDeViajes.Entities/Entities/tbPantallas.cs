﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaDeViajes.Entities
{
    public partial class tbPantallas
    {
        public tbPantallas()
        {
            tbRolesXPantallas = new HashSet<tbRolesXPantallas>();
        }

        public int pant_Id { get; set; }
        public string pant_Nombre { get; set; }
        public string pant_Identificador { get; set; }
        public string pant_href { get; set; }
        public int usua_UsuarioCreacion { get; set; }
        public DateTime pant_FechaCreacion { get; set; }
        public int? usua_UsuarioModificacion { get; set; }
        public DateTime? pant_FechaModificacion { get; set; }
        public bool? pant_Estado { get; set; }

        public virtual tbUsuarios usua_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios usua_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbRolesXPantallas> tbRolesXPantallas { get; set; }
    }
}