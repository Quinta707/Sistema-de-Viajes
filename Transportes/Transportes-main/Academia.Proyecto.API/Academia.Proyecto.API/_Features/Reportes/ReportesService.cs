using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.Reportes.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.Proyecto.API._Features.Reportes
{
    public class ReportesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReportesService(IMapper mapper, UnitOfWorkBuilder unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
        }

        public Respuesta<List<ReporteViajes>> ReporteViajesEmpleados()
        {
            var reporteList = (from empleados in _unitOfWork.Repository<Empleado>().AsQueryable()
                               join sucursalxempleado in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                               on empleados.EmpleadoId equals sucursalxempleado.EmpleadoId
                               join viajedet in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                               on sucursalxempleado.SucursalXempleadoId equals viajedet.SucursalXempleadoId
                               join sucursales in _unitOfWork.Repository<Sucursale>().AsQueryable()
                               on sucursalxempleado.SucursalId equals sucursales.SucursalId
                               where empleados.Estado == true
                               group new ReporteViajes
                               {
                                   EmpleadoId = empleados.EmpleadoId,
                                   EmpleadoNombre = empleados.Nombre,
                                   EmpleadoApellido = empleados.Apellido,
                                   CantidadViajes = viajedet.ViajeId,
                               }
                               by new { EmpleadoId = empleados.EmpleadoId, EmpleadoNombre = empleados.Nombre, EmpleadoApellido = empleados.Apellido, }
                               into emp select new ReporteViajes
                               {
                                   EmpleadoId = emp.Key.EmpleadoId,
                                   EmpleadoNombre = emp.Key.EmpleadoNombre,
                                   EmpleadoApellido = emp.Key.EmpleadoApellido,
                                   CantidadViajes = emp.Count()
                               }).ToList();
            return Respuesta.Success(reporteList, Mensajes.Proceso_Exitoso, Codigos.Success);
            //return Respuesta<List<ReporteViajes>>.Success(reporteList);
        }

        public Respuesta<List<ReporteTotalViajes>> ReporteViajesTransportistas()
        {
            var reporte = (from viajes in _unitOfWork.Repository<Viaje>().AsQueryable()
                            join transportista in _unitOfWork.Repository<Transportista>().AsQueryable()
                            on viajes.TransportistaId equals transportista.TransportistaId
                            select new ReporteTotalViajes
                            {
                                ViajeId = viajes.ViajeId,
                                TransportistaId = viajes.TransportistaId,
                                TransportistaNombre = transportista.Nombre,
                                TransportistaApellido = transportista.Apellido,
                                TarifaPorKm = (int?)transportista.TarifaPorKm,
                                TotalKmViaje = (int?)(from viajedetalle in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                                                       join sucuXEmp in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                                                       on viajedetalle.SucursalXempleadoId equals sucuXEmp.SucursalXempleadoId
                                                       where viajedetalle.ViajeId == viajes.ViajeId
                                                       select sucuXEmp.Kilometros).Sum(),
                                SueldoTotalViaje = (int?)((from viajedetalle in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                                                      join sucuXEmp in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                                                      on viajedetalle.SucursalXempleadoId equals sucuXEmp.SucursalXempleadoId
                                                      where viajedetalle.ViajeId == viajes.ViajeId
                                                      select sucuXEmp.Kilometros).Sum() * transportista.TarifaPorKm)

                            }).ToList();

            return Respuesta.Success<List<ReporteTotalViajes>>(reporte);
        }

    }
}
