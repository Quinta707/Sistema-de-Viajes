﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaDeViajes.Entities
{
    public partial class tbTransportista
    {
        public int tran_Id { get; set; }
        public string tran_Nombre { get; set; }
        public string tran_Apellido { get; set; }
        public string tran_Telefono { get; set; }
        public decimal tran_TarifaPorKM { get; set; }
        public int usua_UsuarioCreacion { get; set; }
        public DateTime tran_FechaCreacion { get; set; }
        public int? usua_UsuarioModificacion { get; set; }
        public DateTime? tran_FechaModificacion { get; set; }
        public bool? tran_Estado { get; set; }

        public virtual tbUsuarios usua_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios usua_UsuarioModificacionNavigation { get; set; }
    }
}