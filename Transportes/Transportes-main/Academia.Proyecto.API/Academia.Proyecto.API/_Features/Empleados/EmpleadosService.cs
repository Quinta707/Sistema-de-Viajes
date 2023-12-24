using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.Empleados.Dtos;
using Academia.Proyecto.API._Features.EstadosCiviles.Dtos;
using Academia.Proyecto.API._Features.Sucursales.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.EstadosCiviles;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.Proyecto.API._Features.Empleados
{
    public class EmpleadosService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmpleadosService(UnitOfWorkBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
            _mapper = mapper;
        }

        public Respuesta<List<EmpleadosListDto>> ListarEmpleados()
        {
            var empleadosList = (from empleados in _unitOfWork.Repository<Empleado>().AsQueryable()
                                 join estadosciviles in _unitOfWork.Repository<EstadosCivile>().AsQueryable()
                                 on empleados.EstadoCivilId equals estadosciviles.EstadoCivilId
                                 where empleados.Estado == true
                                 select new EmpleadosListDto
                                 {
                                     EmpleadoId = empleados.EmpleadoId,
                                     Nombre = empleados.Nombre,
                                     Apellido = empleados.Apellido,
                                     Telefono = empleados.Telefono,
                                     Identidad = empleados.Identidad,
                                     EstadoCivilId = empleados.EstadoCivilId,
                                     EstadoCivilDescripcion = estadosciviles.Descripcion,
                                     Estado = empleados.Estado,
                                 }).ToList();
            return Respuesta.Success(empleadosList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }

        public Respuesta<EmpleadosDto> InsertarEmpleados(EmpleadosDto empleadosDto)
        {

            var empleadosMap = _mapper.Map<Empleado>(empleadosDto);

            _unitOfWork.Repository<Empleado>().Add(empleadosMap);
            _unitOfWork.SaveChanges();


            return Respuesta.Success(empleadosDto, Mensajes.Proceso_Exitoso, Codigos.Success);

        }

        public string EditarEmpleados(EmpleadosDto empleadosDto)
        {
            Empleado? empleadoMapeado = _unitOfWork.Repository<Empleado>().FirstOrDefault(x => x.EmpleadoId == empleadosDto.EmpleadoId);

            empleadoMapeado.EmpleadoId = empleadosDto.EmpleadoId;
            empleadoMapeado.Nombre = empleadosDto.Nombre;
            empleadoMapeado.Apellido = empleadosDto.Apellido;
            empleadoMapeado.Telefono = empleadosDto.Telefono;
            empleadoMapeado.Identidad = empleadosDto.Identidad;
            empleadoMapeado.EstadoCivilId = empleadosDto.EstadoCivilId;
            empleadoMapeado.UsuarioModificacionId = empleadoMapeado.UsuarioModificacionId;
            empleadoMapeado.FechaModicicacion = empleadoMapeado.FechaModicicacion;

            _unitOfWork.SaveChanges();
            empleadosDto.EmpleadoId = empleadoMapeado.EmpleadoId;

            return Mensajes.Proceso_Exitoso;

        }

        public string DesactivarEmpleado(EmpleadosDto empleadosDto)
        {

            Empleado? empleadoMapeado = _unitOfWork.Repository<Empleado>().FirstOrDefault(x => x.EmpleadoId == empleadosDto.EmpleadoId);

            empleadoMapeado.Estado = false;
            empleadoMapeado.UsuarioModificacionId = empleadosDto.UsuarioModificacionId;
            empleadoMapeado.FechaModicicacion = empleadosDto.FechaModicicacion;

            _unitOfWork.SaveChanges();

            empleadoMapeado.EmpleadoId = empleadosDto.EmpleadoId;

            return Mensajes.Proceso_Exitoso;
        }

        public string ActivarEmpleado(EmpleadosDto empleadosDto)
        {
            Empleado? empleadoMapeado = _unitOfWork.Repository<Empleado>().FirstOrDefault(x => x.EmpleadoId == empleadosDto.EmpleadoId);
            empleadoMapeado.Estado = true;
            empleadoMapeado.UsuarioModificacionId = empleadosDto.UsuarioModificacionId;
            empleadoMapeado.FechaModicicacion = empleadosDto.FechaModicicacion;

            _unitOfWork.SaveChanges();

            empleadoMapeado.EmpleadoId = empleadosDto.EmpleadoId;

            return Mensajes.Proceso_Exitoso;
        }
    }
}
