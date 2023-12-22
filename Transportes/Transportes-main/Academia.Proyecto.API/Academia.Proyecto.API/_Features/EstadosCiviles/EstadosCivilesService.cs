using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.Empleados.Dtos;
using Academia.Proyecto.API._Features.EstadosCiviles.Dtos;
using Academia.Proyecto.API._Features.Usuarios.Dtos;
using Academia.Proyecto.API.Domain;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.Proyecto.API._Features.EstadosCiviles
{
    public class EstadosCivilesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EstadosCivilesService(IMapper mapper, UnitOfWorkBuilder unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
        }

        public Respuesta<List<EstadosCivilesDto>> ListarEstadosCiviles()
        {
            var estadoscivlesList = (from estados in _unitOfWork.Repository<EstadosCivile>().AsQueryable()
                                     where estados.Estado == true
                                     select new EstadosCivilesDto
                                     {
                                         EstadoCivilId = estados.EstadoCivilId,
                                         Descripcion = estados.Descripcion,
                                         UsuarioCreacionId = estados.UsuarioCreacionId,
                                         FechaCreacion = estados.FechaCreacion,
                                         UsuarioModificacionId = estados.UsuarioModificacionId,
                                         FechaModicicacion = estados.FechaModicicacion,
                                         Estado = estados.Estado,

                                     }).ToList();

            return Respuesta.Success(estadoscivlesList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }

        public Respuesta<EstadosCivilesDto> InsertarEstadosCiviles(EstadosCivilesDto estadosCivilesDto)
        {

            var estadosmapeados = _mapper.Map<EstadosCivile>(estadosCivilesDto);

            _unitOfWork.Repository<EstadosCivile>().Add(estadosmapeados);
            _unitOfWork.SaveChanges();


            return Respuesta.Success(estadosCivilesDto, Mensajes.Proceso_Exitoso, Codigos.Success);

        }

        
        public string EditarEstadoCivil(EstadosCivilesDto estadosCivilesDto)
        {
            
            EstadosCivile? estadoMapeado = _unitOfWork.Repository<EstadosCivile>().FirstOrDefault(x => x.EstadoCivilId == estadosCivilesDto.EstadoCivilId);

            estadoMapeado.EstadoCivilId = estadosCivilesDto.EstadoCivilId;
            estadoMapeado.Descripcion = estadosCivilesDto.Descripcion;
            estadoMapeado.UsuarioCreacionId = estadosCivilesDto.UsuarioCreacionId;
            estadoMapeado.FechaCreacion = estadosCivilesDto.FechaCreacion;
            estadoMapeado.UsuarioModificacionId = estadosCivilesDto.UsuarioModificacionId;
            estadoMapeado.FechaModicicacion = estadosCivilesDto.FechaModicicacion;
            estadoMapeado.Estado = estadosCivilesDto.Estado;

            _unitOfWork.SaveChanges();
            estadosCivilesDto.EstadoCivilId = estadoMapeado.EstadoCivilId;

            return Mensajes.Proceso_Exitoso;
        }

        public string DesactivarEstadoCivil(EstadosCivilesDto estadosCivilesDto)
        {

            EstadosCivile? estadoMapeado = _unitOfWork.Repository<EstadosCivile>().FirstOrDefault(x => x.EstadoCivilId == estadosCivilesDto.EstadoCivilId);

            estadoMapeado.Estado = false;
            estadoMapeado.UsuarioModificacionId = estadosCivilesDto.UsuarioModificacionId;
            estadoMapeado.FechaModicicacion = estadosCivilesDto.FechaModicicacion;

            _unitOfWork.SaveChanges();

            estadoMapeado.EstadoCivilId = estadosCivilesDto.EstadoCivilId;

            return Mensajes.Proceso_Exitoso;
        }

    }
}
