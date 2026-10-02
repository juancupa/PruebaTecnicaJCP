using PruebaTecnicaJCP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application.Interfaces;

public interface ITipoIdentificacionService
{
    Task<IEnumerable<TipoIdentificacionResponseDTO>> GetTipoIdentificacionResponse();
}
