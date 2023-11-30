using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeViajes.API.Models.Rrhh
{
    public class SucursalesPorEmpleadoViewModel
    {
        public int suem_Id { get; set; }
        public int sucu_Id { get; set; }
        public int empl_Id { get; set; }
        public int suem_Kilometros { get; set; }
        public string suem_Direccion { get; set; }
        public int usua_UsuarioCreacion { get; set; }
        public DateTime suem_FechaCreacion { get; set; }
        public int? usua_UsuarioModificacion { get; set; }
        public DateTime? suem_FechaModificacion { get; set; }
        public bool? suem_Estado { get; set; }
    }
}
