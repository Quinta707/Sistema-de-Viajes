using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.SucursalesXEmpleados.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.Proyecto.API._Features.SucursalesXEmpleados
{
    public class SucursalesXEmpleadoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SucursalesXEmpleadoService(IMapper mapper, UnitOfWorkBuilder unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
        }

        public Respuesta<List<SucursalesXEmpleadoDto>> ListarSucursalXEmpleado()
        {
            var sucurslesXEmpleadoList = (from sucursalempleado in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                                          join empleado in _unitOfWork.Repository<Empleado>().AsQueryable()
                                          on sucursalempleado.EmpleadoId equals empleado.EmpleadoId
                                          join sucursal in _unitOfWork.Repository<Sucursale>().AsQueryable()
                                          on sucursalempleado.SucursalId equals sucursal.SucursalId
                                          where sucursalempleado.Estado == true
                                          select new SucursalesXEmpleadoDto
                                          {
                                              SucursalXempleadoId = sucursalempleado.SucursalXempleadoId,
                                              SucursalId = sucursalempleado.SucursalId,
                                              SucursalNombre = sucursal.Nombre,
                                              EmpleadoId = empleado.EmpleadoId,
                                              EmpleadoNombre = empleado.Nombre,
                                              EmpleadoApellido = empleado.Apellido,
                                              Kilometros = (int?)sucursalempleado.Kilometros,
                                              UsuarioCreacionId = sucursalempleado.UsuarioCreacionId,
                                              Estado = sucursalempleado.Estado,

                                          }).ToList();

            return Respuesta.Success(sucurslesXEmpleadoList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }


        public Respuesta<SucursalesXEmpleadoDto> InsertarSucursalesPorEmpleado(SucursalesXEmpleadoDto sucursalesXEmpleadoDto)
        {

            var Mapeado = _mapper.Map<SucursalesXempleado>(sucursalesXEmpleadoDto);

            _unitOfWork.Repository<SucursalesXempleado>().Add(Mapeado);
            _unitOfWork.SaveChanges();


            return Respuesta.Success(sucursalesXEmpleadoDto, Mensajes.Proceso_Exitoso, Codigos.Success);

        }

        public string EditarSucursalesXEmpleados(SucursalesXEmpleadoDto sucursalesXEmpleadoDto)
        {

            SucursalesXempleado? sucursalesXempleadoMapeado = _unitOfWork.Repository<SucursalesXempleado>().FirstOrDefault(x => x.SucursalXempleadoId == sucursalesXEmpleadoDto.SucursalXempleadoId);
         
            sucursalesXempleadoMapeado.EmpleadoId = sucursalesXEmpleadoDto.EmpleadoId;
            sucursalesXempleadoMapeado.SucursalId = sucursalesXEmpleadoDto.SucursalId;
            sucursalesXempleadoMapeado.Kilometros = sucursalesXEmpleadoDto.Kilometros;
            sucursalesXempleadoMapeado.UsuarioModificacionId = sucursalesXEmpleadoDto.UsuarioModificacionId;
            sucursalesXempleadoMapeado.FechaModicicacion = sucursalesXEmpleadoDto.FechaModicicacion;

            _unitOfWork.SaveChanges();
            sucursalesXempleadoMapeado.SucursalXempleadoId = sucursalesXEmpleadoDto.SucursalXempleadoId;

            return Mensajes.Proceso_Exitoso;
        }

        public string DesactivarSucursalesXEmpleado(SucursalesXEmpleadoDto sucursalesXempleado)
        {

            SucursalesXempleado? Mapeado = _unitOfWork.Repository<SucursalesXempleado>().FirstOrDefault(x => x.SucursalXempleadoId == sucursalesXempleado.SucursalXempleadoId);

            Mapeado.Estado = false;
            Mapeado.UsuarioModificacionId = sucursalesXempleado.UsuarioModificacionId;
            Mapeado.FechaModicicacion = sucursalesXempleado.FechaModicicacion;

            _unitOfWork.SaveChanges();

            Mapeado.SucursalXempleadoId = sucursalesXempleado.SucursalXempleadoId;

            return Mensajes.Proceso_Exitoso;
        }

        public string ActivarSucursalesXEmpleado(SucursalesXEmpleadoDto sucursalesXempleado)
        {

            SucursalesXempleado? Mapeado = _unitOfWork.Repository<SucursalesXempleado>().FirstOrDefault(x => x.SucursalXempleadoId == sucursalesXempleado.SucursalXempleadoId);

            Mapeado.Estado = true;
            Mapeado.UsuarioModificacionId = sucursalesXempleado.UsuarioModificacionId;
            Mapeado.FechaModicicacion = sucursalesXempleado.FechaModicicacion;

            _unitOfWork.SaveChanges();

            Mapeado.SucursalXempleadoId = sucursalesXempleado.SucursalXempleadoId;

            return Mensajes.Proceso_Exitoso;
        }

        public Respuesta<List<SucursalesXEmpleadoDto>> EmpleadosPorSucursalDDL(int? SucursalID)
        {
            var sucurslesXEmpleadoList = (from sucursalempleado in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                                          join empleado in _unitOfWork.Repository<Empleado>().AsQueryable()
                                          on sucursalempleado.EmpleadoId equals empleado.EmpleadoId
                                          join sucursal in _unitOfWork.Repository<Sucursale>().AsQueryable()
                                          on sucursalempleado.SucursalId equals sucursal.SucursalId
                                          where sucursalempleado.Estado == true && sucursal.SucursalId == SucursalID
                                          select new SucursalesXEmpleadoDto
                                          {
                                              SucursalXempleadoId = sucursalempleado.SucursalXempleadoId,
                                              SucursalId = sucursalempleado.SucursalId,
                                              EmpleadoId = empleado.EmpleadoId,
                                              EmpleadoNombre = empleado.Nombre + ' ' + empleado.Apellido,

                                          }).ToList();

            if (sucurslesXEmpleadoList.LongCount() > 0)
            {
                return Respuesta.Success(sucurslesXEmpleadoList, Mensajes.Proceso_Exitoso, Codigos.Success);
            }
            else
            {
                return Respuesta.Fault(Mensajes.No_Hay_Registros, Codigos.Info, sucurslesXEmpleadoList);
            }
}
    }
}
