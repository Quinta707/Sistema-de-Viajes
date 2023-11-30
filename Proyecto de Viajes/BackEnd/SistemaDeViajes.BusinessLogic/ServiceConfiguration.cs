using Microsoft.Extensions.DependencyInjection;
using SistemaDesViajes.DataAccess;
using SistemaDeViajes.BusinessLogic.Services.Acceso;
using SistemaDeViajes.BusinessLogic.Services.Rrhh;
using SistemaDeViajes.DataAccess.Repositories.Acce;
using SistemaDeViajes.DataAccess.Repositories.Rrhh;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeViajes.BusinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection services, string ConnectionString)
        {

            //ACCESO
            services.AddScoped<UsuariosRepository>();
            services.AddScoped<RolesPorPantallaRepository>();
            services.AddScoped<PantallasRepository>();
            services.AddScoped<RolesRepository>();
            //RRHH
            services.AddScoped<EmpleadosRepository>();
            SistemaViajes.BuildConnectionString(ConnectionString);

        }
        public static void BussinessLogic(this IServiceCollection services)
        {
            services.AddScoped<AccesoServices>();
            services.AddScoped<RrhhServices>();

        }
    }
}
