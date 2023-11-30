using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeViajes.DataAccess
{
    public class ScriptsDatabase
    {
        #region ACCESO

        #region Usuarios
        public static string IniciarSesion = "Acce.UDP_IniciarSesion";
        public static string DibujadoMenu = "Acce.UDP_tbPantallas_DibujadoMenu";
        #endregion
        #endregion
        #region RRHH
        #region Empleados
        public static string ListadoEmpleados = "Rrhh.UDP_tbEmpleados_Index";
        #endregion
        #region Viajes
        public static string InsertarSucursalesEmpleado = "Viaj.UDP_tbSucursalesPorEmpleados_Insertar";
        #endregion
        #endregion
    }
}
