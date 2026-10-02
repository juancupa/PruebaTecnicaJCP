using PruebaTecnicaJCP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application.Interfaces;

public interface IUbicacionService
{
    Task<IEnumerable<PaisDto>> ObtenerPaisesAsync();

    Task<IEnumerable<DepartamentoDto>> ObtenerDepartamentosAsync(
        short paisCodigo);

    Task<IEnumerable<MunicipioDto>> ObtenerMunicipiosAsync(
        int departamentoCodigo);
}
