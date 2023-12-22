using Academia.Proyecto.API._Features.Empleados.Dtos;
using Academia.Proyecto.API._Features.EstadosCiviles.Dtos;
using Academia.Proyecto.API._Features.Sucursales.Dtos;
using Academia.Proyecto.API._Features.SucursalesXEmpleados.Dtos;
using Academia.Proyecto.API._Features.Transportistas.Dtos;
using Academia.Proyecto.API._Features.Viajes.Dtos;
using Academia.Proyecto.API._Features.ViajesDetalles.Dtos;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.ViajesMap;
using AutoMapper;

namespace Academia.Proyecto.API.Infrastructure
{
    public class MapProfile : Profile
    {
        public MapProfile() {
            CreateMap<Viaje,                ViajesDto>().ReverseMap();
            CreateMap<ViajesDetalle,        ViajesDetallesDto>().ReverseMap();
            CreateMap<Empleado,             EmpleadosDto>().ReverseMap();
            CreateMap<Sucursale,            SucursalesDto>().ReverseMap();
            CreateMap<SucursalesXempleado,  SucursalesXEmpleadoDto>().ReverseMap();
            CreateMap<Transportista,        TransportistasDto>().ReverseMap();
            CreateMap<EstadosCivile,        EstadosCivilesDto>().ReverseMap();
        }
    }
}
