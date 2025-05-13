using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Libreria.Domain.Repositories;
using Libreria.Infrastructure.Persistence;
using Libreria.Infrastructure.Repositories;
using Libreria.Application.Services.Interfaces;
using Libreria.Application.Services;
using Libreria.Application.Services.Implementations;
using Libreria.Domain.UnitOfWork;
using Libreria.Infrastructure.UnitOfWork;

namespace Libreria.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ILibroService, LibroService>();
            services.AddScoped<IAutorService, AutorService>();
            return services;
        }

       public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
        services.AddDbContext<LibreriaDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<ILibroRepository, LibroRepository>();
        services.AddScoped<IAutorRepository, AutorRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        return services;

        }
    }
}
