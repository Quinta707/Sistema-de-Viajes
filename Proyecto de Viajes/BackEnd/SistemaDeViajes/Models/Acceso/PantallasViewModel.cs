using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeViajes.API.Models.Acceso
{
    public class PantallasViewModel
    {
        public int pant_Id { get; set; }
        public string pant_Nombre { get; set; }
        public string pant_Identificador { get; set; }
        public string pant_href { get; set; }
        public int usua_UsuarioCreacion { get; set; }
        public DateTime pant_FechaCreacion { get; set; }
        public int? usua_UsuarioModificacion { get; set; }
        public DateTime? pant_FechaModificacion { get; set; }
        public bool? pant_Estado { get; set; }
    }
}
