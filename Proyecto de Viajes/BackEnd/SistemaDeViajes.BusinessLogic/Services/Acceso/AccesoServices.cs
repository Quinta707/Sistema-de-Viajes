using SistemaDeViajes.DataAccess.Repositories.Acce;
using SistemaDeViajes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeViajes.BusinessLogic.Services.Acceso
{
    public class AccesoServices
    {
        private readonly UsuariosRepository             _usuariosRepository;
        private readonly RolesPorPantallaRepository     _rolesPorPantallaRepository;
        private readonly RolesRepository                _rolesRepository;
        private readonly PantallasRepository            _pantallasRepository;

        public AccesoServices(  PantallasRepository         pantallasRepository,
                                RolesRepository             rolesRepository,
                                RolesPorPantallaRepository  rolesPorPantallaRepository,
                                UsuariosRepository          usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
            _rolesPorPantallaRepository = rolesPorPantallaRepository;
            _rolesRepository = rolesRepository;
            _pantallasRepository = pantallasRepository;
        }

        public ServiceResult IniciarSesion(tbUsuarios item)
        {
            var resultado = new ServiceResult();
            try
            {
                var usuario = _usuariosRepository.Login(item);

                if (usuario.usua_Nombre == null)
                    return resultado.Forbidden("El usuario o contraseña son incorrectos");
                else
                    return resultado.Ok(usuario);
            }
            catch (Exception ex)
            {
                return resultado.Error(ex.Message);
            }
        }

        public IEnumerable<tbPantallas> DibujadoMenu(int id)
        {
            var result = new ServiceResult();

            var list = _usuariosRepository.DibujadoMenu(id);
            return list;
        }
    }
}
