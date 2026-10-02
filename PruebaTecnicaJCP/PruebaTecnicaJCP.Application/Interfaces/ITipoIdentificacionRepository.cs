using PruebaTecnicaJCP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application.Interfaces;

public interface ITipoIdentificacionRepository
{
    Task<IEnumerable<TipoIdentificacionResponseDTO>> GetTipoIdentificacion();
    Task<TipoIdentificacionResponseDTO?> ObtenerTipoIdentificacionAsync(int id);
    
}
