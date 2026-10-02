using HospitalPatients.Application.Command;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaJCP.Application.DTOs;
using PruebaTecnicaJCP.Application.Interfaces;

namespace PruebaTecnicaJCP.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{

    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllClienteAsync() {

        var response = await _clienteService.ObtenerTodosAsync();
        if (response == null) {

            return NotFound(new ApiResponse<IEnumerable<ClienteResponseDto>>
            {
                Success = false,
                Message = "No se encontraron registros",
                Data = null
            });

        }
        return Ok(new ApiResponse<IEnumerable<ClienteResponseDto>> {

            Success = true,
            Message = "Clientes encontrados",
            Data = response
        });
    }

    [HttpPost]
    public async Task<IActionResult> CrearCliente(ClienteCreateDto request) {

        await _clienteService.CrearAsync(request);
        var response = new ApiResponse<ClienteCreateDto>
        {

            Success = true,
            Message = "Paciente Creado correctamente",
            Data = request
        };
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerClienteIdAsync(int id) {

        var response = await _clienteService.ObtenerPorIdAsync(id);
        if (response == null) {

            return NotFound(new ApiResponse<ClienteResponseDto> {
                Success = false,
                Message = "No se encontro cliente",
                Data = null
            });

        }
        return Ok(new ApiResponse<ClienteResponseDto>
        {

            Success = true,
            Message = "Registro encontrado",
            Data = response

        });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> ActualizarCliente(int id, ClienteUpdateDto cliente) {

        var actualizado =
            await _clienteService.ActualizarAsync(id, cliente);

        if (!actualizado)
        {
            return NotFound(new
            {
                success = false,
                message = "Cliente no encontrado."
            });
        }

        return Ok(new
        {
            success = true,
            message = "Cliente actualizado correctamente."
        });

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarCliente(int id) { 
    
        await _clienteService.DeleteAsync(id);
        var response = new ApiResponse<int>
        {
            Success = true,
            Message = "Cliente eliminado satisfactoriamente",
            Data = id

        };
        return Ok(response);
    }
}


