using PruebaTecnicaJCP.Application.DTOs;
using PruebaTecnicaJCP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application.Service;

public class TipoIdentificacionService : ITipoIdentificacionService
{   

    private readonly ITipoIdentificacionRepository _service;

    public TipoIdentificacionService(ITipoIdentificacionRepository service)
    {
        _service = service;
    }

    public async Task<IEnumerable<TipoIdentificacionResponseDTO>> GetTipoIdentificacionResponse()
    {
        var result = await _service.GetTipoIdentificacion();
        Console.WriteLine("Tipo"+result);
        return result;
    }
}
