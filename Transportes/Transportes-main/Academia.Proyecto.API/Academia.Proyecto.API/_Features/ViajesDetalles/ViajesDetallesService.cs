using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.SucursalesXEmpleados.Dtos;
using Academia.Proyecto.API._Features.ViajesDetalles.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.Proyecto.API._Features.ViajesDetalles
{
    public class ViajesDetallesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ViajesDetallesService(IMapper mapper, UnitOfWorkBuilder unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
        }

        public Respuesta<List<ViajesDetallesListDto>> ListarViajeDetalle()
        {
            //var viajesDetallesList = (from viajedetalle in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
            //                          select viajedetalle).GroupBy(x => x.ViajeId).Select(x => new ViajesDetallesListDto
            //                          {
            //                              ViajeId = x.Key,
            //                              SucursalXempleadoId = x.Count(),
            //                              Kilometros = x.Sum(x => x.Kilometros),
            //                          }).ToList();
            var viajesDetallesList = (from viajedetalle in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                                      join sucursalxempleado in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                                      on viajedetalle.SucursalXempleadoId equals sucursalxempleado.SucursalXempleadoId
                                      join empleados in _unitOfWork.Repository<Empleado>().AsQueryable()
                                      on sucursalxempleado.EmpleadoId equals empleados.EmpleadoId
                                      join sucursales in _unitOfWork.Repository<Sucursale>().AsQueryable()
                                      on sucursalxempleado.SucursalId equals sucursales.SucursalId
                                      where viajedetalle.Estado == true
                                      select new ViajesDetallesListDto
                                      {
                                          ViajeDetalleId = viajedetalle.ViajeDetalleId,
                                          ViajeId = viajedetalle.ViajeId,
                                          SucursalXempleadoId = viajedetalle.SucursalXempleadoId,
                                          EmpleadoNombre = empleados.Nombre,
                                          EmpleadoApellido = empleados.Apellido,
                                          SucursalNombre = sucursales.Nombre,
                                          Kilometros = sucursalxempleado.Kilometros,
                                      }).ToList();
            return Respuesta.Success(viajesDetallesList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }

        public Respuesta<List<ViajesDetallesListDto>> ListarPorViaje(int? ViajeID)
        {
            var viajesDetallesList = (from viajedetalle in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                                      join sucursalxempleado in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                                      on viajedetalle.SucursalXempleadoId equals sucursalxempleado.SucursalXempleadoId
                                      join empleados in _unitOfWork.Repository<Empleado>().AsQueryable()
                                      on sucursalxempleado.EmpleadoId equals empleados.EmpleadoId
                                      join sucursales in _unitOfWork.Repository<Sucursale>().AsQueryable()
                                      on sucursalxempleado.SucursalId equals sucursales.SucursalId
                                      where viajedetalle.Estado == true && viajedetalle.ViajeId == ViajeID
                                      select new ViajesDetallesListDto
                                      {
                                          ViajeDetalleId = viajedetalle.ViajeDetalleId,
                                          ViajeId = viajedetalle.ViajeId,
                                          SucursalXempleadoId = viajedetalle.SucursalXempleadoId,
                                          EmpleadoNombre = empleados.Nombre,
                                          EmpleadoApellido = empleados.Apellido,
                                          SucursalNombre = sucursales.Nombre,
                                          Kilometros = sucursalxempleado.Kilometros,
                                          FechaCreacion = viajedetalle.FechaCreacion,
                                      }).ToList();
            return Respuesta.Success(viajesDetallesList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }

        public Respuesta<ViajesDetallesDto> InsertarViajesDetalles(ViajesDetallesDto viajesDetallesDto)
        {

            var viajesdetallesMapeado = _mapper.Map<ViajesDetalle>(viajesDetallesDto);
            //var a = (from sucursalesPorEmpleado in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                     //join viajesdetalle in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                     //on sucursalesPorEmpleado.SucursalXempleadoId equals viajesdetalle.SucursalXempleadoId

            //         select sucursalesPorEmpleado.Kilometros);
            //viajesdetallesMapeado.SucursalXempleadoId = viajesDetallesDto.SucursalXempleadoId;
            //viajesdetallesMapeado.Kilometros = a;

            _unitOfWork.Repository<ViajesDetalle>().Add(viajesdetallesMapeado);
            _unitOfWork.SaveChanges();


            return Respuesta.Success(viajesDetallesDto, Mensajes.Proceso_Exitoso, Codigos.Success);

        }

        public string EditarViajesDetalles(ViajesDetallesDto viajesDetallesDto)
        {

            ViajesDetalle? viajesDetalleMapeado = _unitOfWork.Repository<ViajesDetalle>().FirstOrDefault(x => x.ViajeDetalleId == viajesDetallesDto.ViajeDetalleId);

            viajesDetalleMapeado.ViajeId = viajesDetallesDto.ViajeId;
            viajesDetalleMapeado.SucursalXempleadoId = viajesDetallesDto.SucursalXempleadoId;
            viajesDetalleMapeado.Kilometros = viajesDetallesDto.Kilometros;
            viajesDetalleMapeado.UsuarioModificacionId = viajesDetallesDto.UsuarioModificacionId;
            viajesDetalleMapeado.FechaModicicacion = viajesDetallesDto.FechaModicicacion;

            _unitOfWork.SaveChanges();
            viajesDetalleMapeado.ViajeDetalleId = viajesDetallesDto.ViajeDetalleId;

            return Mensajes.Proceso_Exitoso;
        }

        public string Desactivar(ViajesDetallesDto viajesDetallesDto)
        {

            ViajesDetalle? viajesDetalleMapeado = _unitOfWork.Repository<ViajesDetalle>().FirstOrDefault(x => x.ViajeDetalleId == viajesDetallesDto.ViajeDetalleId);

            viajesDetalleMapeado.Estado = false;
            viajesDetalleMapeado.UsuarioModificacionId = viajesDetallesDto.UsuarioModificacionId;
            viajesDetalleMapeado.FechaModicicacion = viajesDetallesDto.FechaModicicacion;

            _unitOfWork.SaveChanges();
            viajesDetalleMapeado.ViajeDetalleId = viajesDetallesDto.ViajeDetalleId;

            return Mensajes.Proceso_Exitoso;
        }

        public string Activar(ViajesDetallesDto viajesDetallesDto)
        {

            ViajesDetalle? viajesDetalleMapeado = _unitOfWork.Repository<ViajesDetalle>().FirstOrDefault(x => x.ViajeDetalleId == viajesDetallesDto.ViajeDetalleId);

            viajesDetalleMapeado.Estado = true;
            viajesDetalleMapeado.UsuarioModificacionId = viajesDetallesDto.UsuarioModificacionId;
            viajesDetalleMapeado.FechaModicicacion = viajesDetallesDto.FechaModicicacion;

            _unitOfWork.SaveChanges();
            viajesDetalleMapeado.ViajeDetalleId = viajesDetallesDto.ViajeDetalleId;

            return Mensajes.Proceso_Exitoso;
        }

    }
}
