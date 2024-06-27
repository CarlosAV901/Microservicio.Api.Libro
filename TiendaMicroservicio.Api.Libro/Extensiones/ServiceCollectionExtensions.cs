using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaMicroservicio.Api.Libro.Aplicacion;
using TiendaMicroservicio.Api.Libro.Persistencia;
using TiendaServicios.Api.Libro.Aplicacion;

namespace TiendaMicroservicio.Api.Libro.Extensiones;

public static class ServiceCollectionExtensions
{
    [Obsolete]
    public static IServiceCollection AddCustomService(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddControllers()
            .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());


        services.AddDbContext<ContextoLibreria>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
        services.AddAutoMapper(typeof(Consulta.Manejador));

        return services;
    }
}