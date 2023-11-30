using Dapper;
using Microsoft.Data.SqlClient;
using SistemaDesViajes.DataAccess;
using SistemaDeViajes.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeViajes.DataAccess.Repositories.Rrhh
{
    public class EmpleadosRepository : IRepository<tbEmpleados>
    {
        public RequestStatus InsertSucu(tbSucursalesPorEmpleados item)
        {
            using var db = new SqlConnection(SistemaViajes.ConnectionString);
            RequestStatus result = new RequestStatus();
            var parametros = new DynamicParameters();
            parametros.Add("@sucu_Id", item.sucu_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empl_Id", item.empl_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@suem_Kilometros", item.suem_Kilometros, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@usua_UsuarioCreacion", item.usua_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);
            var answer = db.QueryFirst<string>(ScriptsDatabase.InsertarSucursalesEmpleado, parametros, commandType: CommandType.StoredProcedure);
            result.MessageStatus = answer;
            return result;
        }

        public RequestStatus Delete(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public tbEmpleados Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEmpleados> List()
        {
            using var db = new SqlConnection(SistemaViajes.ConnectionString);
            var parametros = new DynamicParameters();
            return db.Query<tbEmpleados>(ScriptsDatabase.ListadoEmpleados, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbEmpleados item)
        {
            throw new NotImplementedException();
        }
    }
}
