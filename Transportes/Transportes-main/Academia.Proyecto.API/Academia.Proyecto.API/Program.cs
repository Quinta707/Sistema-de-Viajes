using Academia.Proyecto.API._Features.Empleados;
using Academia.Proyecto.API._Features.EstadosCiviles;
using Academia.Proyecto.API._Features.Reportes;
using Academia.Proyecto.API._Features.Sucursales;
using Academia.Proyecto.API._Features.SucursalesXEmpleados;
using Academia.Proyecto.API._Features.Transportistas;
using Academia.Proyecto.API._Features.Usuarios;
using Academia.Proyecto.API._Features.Viajes;
using Academia.Proyecto.API._Features.ViajesDetalles;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB;
using Farsiman.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ProyectoTransporte");
builder.Services.AddDbContext<TransporteSeqpContext>(opciones => opciones.UseSqlServer(connectionString));

builder.Services.AddTransient<UnitOfWorkBuilder, UnitOfWorkBuilder>();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddTransient<ViajesService>();
builder.Services.AddTransient<ViajesDetallesService>();
builder.Services.AddTransient<EmpleadosService>();
builder.Services.AddTransient<TransportistasService>();
builder.Services.AddTransient<SucursalesService>();
builder.Services.AddTransient<SucursalesXEmpleadoService>();
builder.Services.AddTransient<EstadosCivilesService>();
builder.Services.AddTransient<UsuariosService>();
builder.Services.AddTransient<ReportesService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSwaggerForFsIdentityServer(opt =>
//{
//    opt.Title = "AcademiaFS";
//    opt.Description = "Proyecto de transporte";
//    opt.Version = "v1.0";
//});

//builder.Services.AddFsAuthService(configureOptions =>
//{
//    configureOptions.Username = builder.Configuration.GetFromENV("Configurations:FsIdentityServer:Username");
//    configureOptions.Password = builder.Configuration.GetFromENV("Configurations:FsIdentityServer:Password");
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerWithFsIdentityServer();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseFsAuthService();

app.MapControllers();

app.Run();
