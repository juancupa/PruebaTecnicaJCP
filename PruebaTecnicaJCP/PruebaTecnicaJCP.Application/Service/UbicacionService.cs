using PruebaTecnicaJCP.Application.DTOs;
using PruebaTecnicaJCP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application.Service;

public class UbicacionService : IUbicacionService
{

    private readonly IUbicacionRepository _ubicacionRepository;

    public UbicacionService(IUbicacionRepository ubicacionRepository)
    {
        _ubicacionRepository = ubicacionRepository;
    }




    public Task<IEnumerable<DepartamentoDto>> ObtenerDepartamentosAsync(short paisCodigo)
    {
        return _ubicacionRepository.ObtenerDepartamentosAsync(paisCodigo);
    }

    public Task<IEnumerable<MunicipioDto>> ObtenerMunicipiosAsync(int departamentoCodigo)
    {
        return _ubicacionRepository.ObtenerMunicipiosAsync(departamentoCodigo);
    }

    public Task<IEnumerable<PaisDto>> ObtenerPaisesAsync()
    {
        return _ubicacionRepository.ObtenerPaisesAsync();
    }
}
