using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeViajes.API.Models.Acceso;
using SistemaDeViajes.BusinessLogic.Services.Acceso;
using SistemaDeViajes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeViajes.API.Controllers.Acceso
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AccesoServices _accesoServices;
        private readonly IMapper _mapper;

        public UsuariosController(AccesoServices accesoService, IMapper mapper)
        {
            _accesoServices = accesoService;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public IActionResult InicioSesion(UsuariosViewModel usuarios)
        {
            var mapped = _mapper.Map<tbUsuarios>(usuarios);
            var respuesta = _accesoServices.IniciarSesion(mapped);

            if (respuesta.Code == 200)
            {
                respuesta.Data = _mapper.Map<UsuariosViewModel>(respuesta.Data);

                return Ok(respuesta);

            }
            else
            {
                return StatusCode(203, respuesta);
            }
        }

        [HttpGet("DibujadoMenu")]
        public IActionResult DibujadoMenu(int id)
        {
            var list = _accesoServices.DibujadoMenu(id);
            return Ok(list);
        }
    }
}
