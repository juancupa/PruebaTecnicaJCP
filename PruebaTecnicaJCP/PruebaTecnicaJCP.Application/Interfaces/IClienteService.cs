using PruebaTecnicaJCP.Application.DTOs;
using PruebaTecnicaJCP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application.Interfaces;

public interface IClienteService
{
    Task<int> CrearAsync(ClienteCreateDto cliente);
    Task<ClienteResponseDto?> ObtenerPorIdAsync(int id);

    Task<IEnumerable<ClienteResponseDto>> ObtenerTodosAsync();

    Task<bool> ActualizarAsync(int id, ClienteUpdateDto cliente);
    Task DeleteAsync(int id);
}
