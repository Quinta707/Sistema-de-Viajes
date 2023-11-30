using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeViajes.API.Models.Acceso
{
    public class UsuariosViewModel
    {
        public int usua_Id { get; set; }
        public string usua_Nombre { get; set; }
        public string usua_Contrasenia { get; set; }
        public int empl_Id { get; set; }
        public string usua_Image { get; set; }
        public int role_Id { get; set; }
        public bool usua_EsAdmin { get; set; }
        public int usua_UsuarioCreacion { get; set; }
        public DateTime usua_FechaCreacion { get; set; }
        public int? usua_UsuarioModificacion { get; set; }
        public DateTime? usua_FechaModificacion { get; set; }
        public bool? usua_Estado { get; set; }
        public int pant_Id { get; set; }
        public string pant_Nombre { get; set; }
        public string pant_Identificador { get; set; }
        public string pant_href { get; set; }
        public DateTime pant_FechaCreacion { get; set; }
        public DateTime? pant_FechaModificacion { get; set; }
        public bool? pant_Estado { get; set; }
    }
}
