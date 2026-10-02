using PruebaTecnicaJCP.Application.DTOs;
using PruebaTecnicaJCP.Application.Interfaces;
using PruebaTecnicaJCP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application.Service;

public class ClienteService : IClienteService
{


    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<bool> ActualizarAsync(int id, ClienteUpdateDto cliente)
    {
        return await _clienteRepository.ActualizarAsync(id, cliente);
    }

    public async Task<int> CrearAsync(ClienteCreateDto cliente)
    {
        return  await _clienteRepository.CrearAsync(cliente);
    }

   /* public async Task CreateClienteAsync(CreateClienteRequest request)
    {
        var cliente = new Cliente { 
        
            ClnTpoIdnId=request.ClnTpoIdnId,
            ClnNumeroIdentificacion=request.ClnNumeroIdentificacion,
            ClRazonSocial=request.ClRazonSocial,
            ClnPaisCodigo=request.ClnPaisCodigo,
            ClnDptColcodigoDane=request.lnDptColcodigoDane,
            ClnDvsPltColCodigoDane=request.ClnDvsPltColCodigoDane

        };

        await _clienteRepository.CreateClienteAsync(cliente);

    }*/


    public async Task DeleteAsync(int id)
    {
      await _clienteRepository.DeleteAsync(id);
    }

    /*public async Task<IEnumerable<ClienteResponse>> GetAllAsync()
    {
        
        var result = await _clienteRepository.GetAllAsync();
        if (result == null) {
            throw new Exception("No hay registros");
        }
        return result;

    }*/

    /*public async Task<ClienteResponse?> GetByIdentificacionAsync(int id)
    {
        var result = await _clienteRepository.GetByIdentificacionAsync(id);
        Console.WriteLine("ID",result);
        return result;
    }*/

    public async Task<ClienteResponseDto?> ObtenerPorIdAsync(int id)
    {
        return await _clienteRepository.ObtenerPorIdAsync(id);
    }

    public async Task<IEnumerable<ClienteResponseDto>> ObtenerTodosAsync()
    {
        return await _clienteRepository.ObtenerTodosAsync();
    }

    /*public Task<bool> UpdateAsync(UpdateClienteRequest request)
    {
        throw new NotImplementedException();
    }*/
}
