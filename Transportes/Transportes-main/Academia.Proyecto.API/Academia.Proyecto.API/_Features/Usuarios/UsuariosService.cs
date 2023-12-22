using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.Usuarios.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.Proyecto.API._Features.Usuarios
{
    public class UsuariosService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsuariosService(IMapper mapper, UnitOfWorkBuilder unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
        }

        public Respuesta<List<UsuariosDto>> ListarUsuarios()
        {
            var usuarioList = (from usuario in _unitOfWork.Repository<Usuario>().AsQueryable()
                               join empleado in _unitOfWork.Repository<Empleado>().AsQueryable()
                               on usuario.EmpleadoId equals empleado.EmpleadoId
                               where usuario.Estado == true
                               select new UsuariosDto
                               {
                                   UsuarioId = usuario.UsuarioId,
                                   EmpleadoId = empleado.EmpleadoId,
                                   EmpleadoNombre = empleado.Nombre,
                                   EmpleadoApellido = empleado.Apellido,
                                   Usuario1 = usuario.Usuario1,
                                   Estado = usuario.Estado,
                               }).ToList();

            return Respuesta.Success(usuarioList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }
    }
}
