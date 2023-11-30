using SistemaDeViajes.DataAccess.Repositories.Rrhh;
using SistemaDeViajes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeViajes.BusinessLogic.Services.Rrhh
{
    public class RrhhServices
    {
        private readonly EmpleadosRepository _empleadosRepository;

        public RrhhServices (EmpleadosRepository empleadosRepository )
        {
            _empleadosRepository = empleadosRepository;
        }

        public ServiceResult ListarEmpleados()
        {
            var resultado = new ServiceResult();

            try
            {
                var list = _empleadosRepository.List();
                return resultado.Ok(list);
            }
            catch (Exception ex)
            {
                return resultado.Error(ex.Message);
            }
        }

        public ServiceResult InsertarSucursalEmpleado(tbSucursalesPorEmpleados item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _empleadosRepository.InsertSucu(item);
                if (map.MessageStatus == "1")
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
    }
}
