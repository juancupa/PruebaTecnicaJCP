using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaJCP.Application.Interfaces;
using PruebaTecnicaJCP.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddAplication(this IServiceCollection services) {

        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<ITipoIdentificacionService, TipoIdentificacionService>();
        services.AddScoped<IUbicacionService, UbicacionService>();
        
        return services;
    }

}
