using AutoMapper;
using SistemaDeViajes.API.Models.Acceso;
using SistemaDeViajes.API.Models.Rrhh;
using SistemaDeViajes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeViajes.API.Extensions
{
    public class MappingProfileExtensions : Profile
    {
        public MappingProfileExtensions()
        {
            #region Generales
            //CreateMap<AldeasViewModel, tbAldeas>().ReverseMap();
            //CreateMap<CargosViewModel, tbCargos>().ReverseMap();
            //CreateMap<CiudadesViewModel, tbCiudades>().ReverseMap();
            //CreateMap<ColoniasViewModel, tbColonias>().ReverseMap();
            //CreateMap<EmpleadosViewModel, tbEmpleados>().ReverseMap();
            //CreateMap<EstadosCivilesViewModel, tbEstadosCiviles>().ReverseMap();
            //CreateMap<Formas_EnvioViewModel, tbFormas_Envio>().ReverseMap();
            //CreateMap<MonedasViewModel, tbMonedas>().ReverseMap();
            //CreateMap<OficinasViewModel, tbOficinas>().ReverseMap();
            //CreateMap<Oficio_ProfesionesViewModel, tbOficio_Profesiones>().ReverseMap();
            //CreateMap<PaisesViewModel, tbPaises>().ReverseMap();
            //CreateMap<ProveedoresViewModel, tbProveedores>().ReverseMap();
            //CreateMap<ProvinciasViewModel, tbProvincias>().ReverseMap();
            //CreateMap<UnidadMedidaViewModel, tbUnidadMedidas>().ReverseMap();
            #endregion

            #region Acceso
            CreateMap<UsuariosViewModel, tbUsuarios>().ReverseMap();
            CreateMap<EmpleadosViewModel, tbEmpleados>().ReverseMap();
            CreateMap<PantallasViewModel, tbPantallas>().ReverseMap();
            CreateMap<SucursalesPorEmpleadoViewModel, tbSucursalesPorEmpleados>().ReverseMap();
            //CreateMap<PantallasViewModel, tbPantallas>().ReverseMap();
            //CreateMap<RolesViewModel, tbRoles>().ReverseMap();
            //CreateMap<RolesPorPantallasViewModel, tbRolesXPantallas>().ReverseMap();

            #endregion

        }
    }
}
