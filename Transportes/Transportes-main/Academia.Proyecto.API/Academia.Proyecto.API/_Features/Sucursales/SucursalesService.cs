using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.EstadosCiviles.Dtos;
using Academia.Proyecto.API._Features.Sucursales.Dtos;
using Academia.Proyecto.API._Features.Sucursales.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.Proyecto.API._Features.Sucursales
{
    public class SucursalesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SucursalesService(IMapper mapper, UnitOfWorkBuilder unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
        }

        public Respuesta<List<SucursalesDto>> ListarSucursales()
        {
            var sucursalesList = (from sucursales in _unitOfWork.Repository<Sucursale>().AsQueryable()
                                  where sucursales.Estado == true
                                  select new SucursalesDto
                                  {
                                      SucursalId = sucursales.SucursalId,
                                      Nombre = sucursales.Nombre,
                                      UsuarioCreacionId = sucursales.UsuarioCreacionId,
                                      FechaCreacion = sucursales.FechaCreacion,
                                      UsuarioModificacionId = sucursales.UsuarioModificacionId,
                                      FechaModicicacion = sucursales.FechaModicicacion,
                                      Estado = sucursales.Estado,
                                  }).ToList();
            return Respuesta.Success(sucursalesList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }

        public Respuesta<SucursalesDto> InsertarSucursales(SucursalesDto sucursalesDto)
        {

            var sucursalesmap = _mapper.Map<Sucursale>(sucursalesDto);

            _unitOfWork.Repository<Sucursale>().Add(sucursalesmap);
            _unitOfWork.SaveChanges();


            return Respuesta.Success(sucursalesDto, Mensajes.Proceso_Exitoso, Codigos.Success);

        }


        public string EditarSucursales(SucursalesDto sucursalesDto)
        {

            Sucursale? sucursalesmap = _unitOfWork.Repository<Sucursale>().FirstOrDefault(x => x.SucursalId == sucursalesDto.SucursalId);

            sucursalesmap.SucursalId = sucursalesDto.SucursalId;
            sucursalesmap.Nombre = sucursalesDto.Nombre;
            sucursalesmap.UsuarioCreacionId = sucursalesDto.UsuarioCreacionId;
            sucursalesmap.FechaCreacion = sucursalesDto.FechaCreacion;
            sucursalesmap.UsuarioModificacionId = sucursalesDto.UsuarioModificacionId;
            sucursalesmap.FechaModicicacion = sucursalesDto.FechaModicicacion;
            sucursalesmap.Estado = sucursalesDto.Estado;

            _unitOfWork.SaveChanges();
            sucursalesDto.SucursalId = sucursalesmap.SucursalId;

            return Mensajes.Proceso_Exitoso;
        }

        public string DesactivarSucursales (SucursalesDto sucursalesDto)
        {

            Sucursale? sucursalMapeado = _unitOfWork.Repository<Sucursale>().FirstOrDefault(x => x.SucursalId == sucursalesDto.SucursalId);

            sucursalMapeado.Estado = false;
            sucursalMapeado.UsuarioModificacionId = sucursalesDto.UsuarioModificacionId;
            sucursalMapeado.FechaModicicacion = sucursalesDto.FechaModicicacion;

            _unitOfWork.SaveChanges();

            sucursalMapeado.SucursalId = sucursalesDto.SucursalId;

            return Mensajes.Proceso_Exitoso;
        }
    }
}
