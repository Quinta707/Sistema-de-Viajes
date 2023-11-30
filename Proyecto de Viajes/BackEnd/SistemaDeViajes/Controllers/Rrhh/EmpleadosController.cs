using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeViajes.API.Models.Rrhh;
using SistemaDeViajes.BusinessLogic.Services.Rrhh;
using SistemaDeViajes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeViajes.API.Controllers.Rrhh
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly RrhhServices _rrhhServices;
        private readonly IMapper _mapper;

        public EmpleadosController(RrhhServices rrhhservices, IMapper mapper)
        {
            _rrhhServices = rrhhservices;
            _mapper = mapper;
        }
        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var listado = _rrhhServices.ListarEmpleados();
            listado.Data = _mapper.Map<IEnumerable<EmpleadosViewModel>>(listado.Data);
            return Ok(listado);
        }

        [HttpPost("SucursalesEmpleado")]
        public IActionResult Insertar(SucursalesPorEmpleadoViewModel rolesPantalla)
        {
            var mapped = _mapper.Map<tbSucursalesPorEmpleados>(rolesPantalla);
            var datos = _rrhhServices.InsertarSucursalEmpleado(mapped);
            return Ok(datos);
        }
    }
}
