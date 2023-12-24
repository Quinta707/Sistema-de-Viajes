using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.SucursalesXEmpleados.Dtos;
using Academia.Proyecto.API._Features.Transportistas.Dtos;
using Academia.Proyecto.API._Features.Usuarios.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Academia.Proyecto.API._Features.Transportistas
{
    public class TransportistasService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransportistasService(IMapper mapper, UnitOfWorkBuilder unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
        }

        public Respuesta<List<TransportistasDto>> ListarTransportista()
        {
            var transportistaList = (from transp in _unitOfWork.Repository<Transportista>().AsQueryable()
                                     join estadocivil in _unitOfWork.Repository<EstadosCivile>().AsQueryable()
                                     on transp.EstadoCivilId equals estadocivil.EstadoCivilId
                                     join usuariocrea in _unitOfWork.Repository<Usuario>().AsQueryable()
                                     on transp.UsuarioCreacionId equals usuariocrea.UsuarioId
                                     //join usuadiomodifica in _unitOfWork.Repository<Usuario>().AsQueryable()
                                     //on transp.UsuarioModificacionId equals usuadiomodifica.UsuarioId
                                     where transp.Estado == true
                                     select new TransportistasDto
                                     {
                                         TransportistaId = transp.TransportistaId,
                                         Nombre = transp.Nombre,
                                         Apellido = transp.Apellido,
                                         Telefono = transp.Telefono,
                                         Identidad = transp.Identidad,
                                         EstadoCivilId = transp.EstadoCivilId,
                                         EstadoCivilDescripcion = estadocivil.Descripcion,
                                         TarifaPorKm = transp.TarifaPorKm,
                                         UsuarioCreacionId = transp.UsuarioCreacionId,
                                         UsuarioCreacionNombre = usuariocrea.Usuario1,
                                         FechaCreacion = transp.FechaCreacion,
                                         UsuarioModificacionId = transp.UsuarioModificacionId,
                                         FechaModicicacion = transp.FechaModicicacion,
                                         Estado = transp.Estado,

                                     }).ToList();
            return Respuesta.Success(transportistaList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }


        public Respuesta<TransportistasDto> InsertarTransportistas(TransportistasDto transportistasDto)
        {

            var empleadosMap = _mapper.Map<Transportista>(transportistasDto);

            _unitOfWork.Repository<Transportista>().Add(empleadosMap);
            _unitOfWork.SaveChanges();


            return Respuesta.Success(transportistasDto, Mensajes.Proceso_Exitoso, Codigos.Success);

        }

        public string EditarTransportistas(TransportistasDto transportistasDto)
        {
            Transportista? transportistaMapeado = _unitOfWork.Repository<Transportista>().FirstOrDefault(x => x.TransportistaId == transportistasDto.TransportistaId);

            transportistaMapeado.TransportistaId = transportistasDto.TransportistaId;
            transportistaMapeado.Nombre = transportistasDto.Nombre;
            transportistaMapeado.Apellido = transportistasDto.Apellido;
            transportistaMapeado.Telefono = transportistasDto.Telefono;
            transportistaMapeado.Identidad = transportistasDto.Identidad;
            transportistaMapeado.TarifaPorKm = transportistasDto.TarifaPorKm;
            transportistaMapeado.UsuarioModificacionId = transportistaMapeado.UsuarioModificacionId;
            transportistaMapeado.FechaModicicacion = transportistaMapeado.FechaModicicacion;

            _unitOfWork.SaveChanges();
            transportistasDto.TransportistaId = transportistaMapeado.TransportistaId;

            return Mensajes.Proceso_Exitoso;

        }

        public string DesactivarTransportista(TransportistasDto transportistasDto)
        {

            Transportista? Mapeado = _unitOfWork.Repository<Transportista>().FirstOrDefault(x => x.TransportistaId == transportistasDto.TransportistaId);

            Mapeado.Estado = false;
            Mapeado.UsuarioModificacionId = transportistasDto.UsuarioModificacionId;
            Mapeado.FechaModicicacion = transportistasDto.FechaModicicacion;

            _unitOfWork.SaveChanges();

            Mapeado.TransportistaId = transportistasDto.TransportistaId;

            return Mensajes.Proceso_Exitoso;
        }

        public string ActivarTransportista(TransportistasDto transportistasDto)
        {

            Transportista? Mapeado = _unitOfWork.Repository<Transportista>().FirstOrDefault(x => x.TransportistaId == transportistasDto.TransportistaId);

            Mapeado.Estado = true;
            Mapeado.UsuarioModificacionId = transportistasDto.UsuarioModificacionId;
            Mapeado.FechaModicicacion = transportistasDto.FechaModicicacion;

            _unitOfWork.SaveChanges();

            Mapeado.TransportistaId = transportistasDto.TransportistaId;

            return Mensajes.Proceso_Exitoso;
        }
    }
}


