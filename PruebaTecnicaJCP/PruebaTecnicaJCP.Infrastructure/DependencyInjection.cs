using HospitalPatients.Infraestructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaJCP.Application.Interfaces;
using PruebaTecnicaJCP.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<ITipoIdentificacionRepository, TipoIdentificacionRepository>();
        services.AddScoped<IUbicacionRepository, UbicacionRepository>();
        IServiceCollection seviceCollection = services.AddSingleton<IDbConnectionFactory>(_ = new DbConectionFactory(configuration));
        return services;
    }

}
