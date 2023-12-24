using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.Viajes.Dtos;
using Academia.Proyecto.API._Features.ViajesDetalles.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;

namespace Academia.Proyecto.API._Features.Viajes
{
    public class ViajesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ViajesService(UnitOfWorkBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
            _mapper = mapper;
        }

        public Respuesta<List<ViajesListDto>> ListarViajes()
        {
            var viajesList = (from viaje in _unitOfWork.Repository<Viaje>().AsQueryable()
                              join transp in _unitOfWork.Repository<Transportista>().AsQueryable()
                              on viaje.TransportistaId equals transp.TransportistaId
                              where viaje.Estado == true
                              select new ViajesListDto
                              {
                                  ViajeId = viaje.ViajeId,
                                  FechaViaje = viaje.FechaViaje,
                                  TransportistaId = transp.TransportistaId,
                                  TransportistaNombre = transp.Nombre,
                                  TransportistaApellido = transp.Apellido,
                                  TarifaPorKm = transp.TarifaPorKm,
                                  ViajesDetalles = (from viajedetalle in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                                                    join viajes in _unitOfWork.Repository<Viaje>().AsQueryable()
                                                    on viajedetalle.ViajeId equals viajes.ViajeId
                                                    join sucursalxempleado in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                                                    on viajedetalle.SucursalXempleadoId equals sucursalxempleado.SucursalXempleadoId
                                                    join empleados in _unitOfWork.Repository<Empleado>().AsQueryable()
                                                    on sucursalxempleado.EmpleadoId equals empleados.EmpleadoId
                                                    join sucursales in _unitOfWork.Repository<Sucursale>().AsQueryable()
                                                    on sucursalxempleado.SucursalId equals sucursales.SucursalId
                                                    where viajedetalle.ViajeId == viaje.ViajeId
                                                    select new ViajesDetallesListDto 
                                                    {
                                                        ViajeDetalleId = viajedetalle.ViajeDetalleId,
                                                        SucursalXempleadoId = sucursalxempleado.SucursalXempleadoId,
                                                        EmpleadoId = sucursalxempleado.EmpleadoId,
                                                        EmpleadoNombre = empleados.Nombre,
                                                        EmpleadoApellido = empleados.Apellido,
                                                        SucursalId = sucursalxempleado.SucursalId,
                                                        SucursalNombre = sucursales.Nombre,
                                                        Kilometros = sucursalxempleado.Kilometros,
                                                        ViajeId = viajedetalle.ViajeId,
                                                        UsuarioCreacionId = viajedetalle.UsuarioCreacionId,
                                                        FechaCreacion = viajedetalle.FechaCreacion,
                                                        UsuarioModificacionId = viajedetalle.UsuarioModificacionId,
                                                        FechaModicicacion = viajedetalle.FechaModicicacion,

                                                    }).ToList(),

                              }).ToList();
            return Respuesta.Success(viajesList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }

        public Respuesta<List<ViajesListDto>> ListarViajesPorTransportista(int? TransportistaID)
        {
            var viajesList = (from viaje in _unitOfWork.Repository<Viaje>().AsQueryable()
                              join transp in _unitOfWork.Repository<Transportista>().AsQueryable()
                              on viaje.TransportistaId equals transp.TransportistaId
                              where viaje.Estado == true && viaje.TransportistaId == TransportistaID
                              select new ViajesListDto
                              {
                                  ViajeId = viaje.ViajeId,
                                  FechaViaje = viaje.FechaViaje,
                                  TransportistaId = transp.TransportistaId,
                                  TransportistaNombre = transp.Nombre,
                                  TransportistaApellido = transp.Apellido,
                                  TarifaPorKm = transp.TarifaPorKm,
                                  ViajesDetalles = (from viajedetalle in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                                                    join viajes in _unitOfWork.Repository<Viaje>().AsQueryable()
                                                    on viajedetalle.ViajeId equals viajes.ViajeId
                                                    join sucursalxempleado in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                                                    on viajedetalle.SucursalXempleadoId equals sucursalxempleado.SucursalXempleadoId
                                                    join empleados in _unitOfWork.Repository<Empleado>().AsQueryable()
                                                    on sucursalxempleado.EmpleadoId equals empleados.EmpleadoId
                                                    join sucursales in _unitOfWork.Repository<Sucursale>().AsQueryable()
                                                    on sucursalxempleado.SucursalId equals sucursales.SucursalId
                                                    where viajedetalle.ViajeId == viaje.ViajeId 
                                                    select new ViajesDetallesListDto
                                                    {
                                                        ViajeDetalleId = viajedetalle.ViajeDetalleId,
                                                        SucursalXempleadoId = sucursalxempleado.SucursalXempleadoId,
                                                        EmpleadoId = sucursalxempleado.EmpleadoId,
                                                        EmpleadoNombre = empleados.Nombre,
                                                        EmpleadoApellido = empleados.Apellido,
                                                        SucursalId = sucursalxempleado.SucursalId,
                                                        SucursalNombre = sucursales.Nombre,
                                                        Kilometros = sucursalxempleado.Kilometros,
                                                        ViajeId = viajedetalle.ViajeId,
                                                        UsuarioCreacionId = viajedetalle.UsuarioCreacionId,
                                                        FechaCreacion = viajedetalle.FechaCreacion,
                                                        UsuarioModificacionId = viajedetalle.UsuarioModificacionId,
                                                        FechaModicicacion = viajedetalle.FechaModicicacion,

                                                    }).ToList(),

                              }).ToList();
            if(viajesList.LongCount() > 0) 
            {
                return Respuesta.Success(viajesList, Mensajes.Proceso_Exitoso, Codigos.Success);
            }
            else
            {
                return Respuesta.Fault(Mensajes.No_Hay_Registros, Codigos.Info, viajesList);
            }
        }

    }
}

