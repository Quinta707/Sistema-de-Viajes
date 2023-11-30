using Dapper;
using Microsoft.Data.SqlClient;
using SistemaDesViajes.DataAccess;
using SistemaDeViajes.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaDeViajes.DataAccess.Repositories.Acce
{
    public class UsuariosRepository : IRepository<tbUsuarios>
    {
        public tbUsuarios Login(tbUsuarios item)
        {
            using var db = new SqlConnection(SistemaViajes.ConnectionString);

            var parametros = new DynamicParameters();

            parametros.Add("@usua_Nombre", item.usua_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@usua_Contrasenia", item.usua_Contrasenia, DbType.String, ParameterDirection.Input);

            var resultado = db.QueryFirst<tbUsuarios>(ScriptsDatabase.IniciarSesion, parametros, commandType: CommandType.StoredProcedure);
            return resultado;
        }

        public IEnumerable<tbPantallas> DibujadoMenu(int id)
        {
            using var db = new SqlConnection(SistemaViajes.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@usua_Id", id, DbType.String, ParameterDirection.Input);

            var result = db.Query<tbPantallas>(ScriptsDatabase.DibujadoMenu, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public RequestStatus Delete(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public tbUsuarios Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbUsuarios> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

    }
}
