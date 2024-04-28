using MediatR;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using libreriaCrud.App.Libro;
using libreriaCrud.Persistence.Libro;
using libreriaCrud.Persistence.Autor;
using libreriaCrud.Persistence.Usuario;
using libreriaCrud.App.Autor;
using libreriaCrud.App.Usuario;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

//------------------------------ Inyeccion de controlador de las validaciones de entrada ---------------------------------

builder.Services.AddControllers().AddFluentValidation(cfg =>
{

    cfg.RegisterValidatorsFromAssemblyContaining<libroAgregar>();
    cfg.RegisterValidatorsFromAssemblyContaining<libroActualizar>();

    cfg.RegisterValidatorsFromAssemblyContaining<autorAgregar>();
    cfg.RegisterValidatorsFromAssemblyContaining<autorActualizar>();

    cfg.RegisterValidatorsFromAssemblyContaining<usuarioAgregar>();

});

//------------------------------ Inyeccion de mapeado de consultas ---------------------------------

builder.Services.AddAutoMapper(typeof(libroConsulta.Ejecuta));
builder.Services.AddAutoMapper(typeof(autorConsulta.Ejecuta));

builder.Services.AddControllers();

//------------------------------ Inyeccion de la persistencias ---------------------------
builder.Services.AddDbContext<autorPersistence>(apt =>
{
    apt.UseSqlServer(configuration.GetConnectionString("ConexionDB"));
});

builder.Services.AddDbContext<libroPersistence>(apt =>
{
    apt.UseSqlServer(configuration.GetConnectionString("ConexionDB"));
});

builder.Services.AddDbContext<usuarioPersistence>(apt =>
{
    apt.UseSqlServer(configuration.GetConnectionString("ConexionDB"));
});

//------------------------------ Inyeccion de MediatR ---------------------------------

builder.Services.AddMediatR(typeof(libroAgregar.Manejador).Assembly);
builder.Services.AddMediatR(typeof(libroActualizar.Manejador).Assembly);
builder.Services.AddMediatR(typeof(autorAgregar.Manejador).Assembly);
builder.Services.AddMediatR(typeof(autorActualizar.Manejador).Assembly);
builder.Services.AddMediatR(typeof(usuarioAgregar.Manejador).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
