using HospitalPatients.Application.Command;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaJCP.Application.DTOs;
using PruebaTecnicaJCP.Application.Interfaces;

namespace PruebaTecnicaJCP.Api.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class TipoIdentificacionController : ControllerBase
    {

        private readonly ITipoIdentificacionService _tipoIdentificacionService;

        public TipoIdentificacionController(ITipoIdentificacionService tipoIdentificacionService)
        {
            _tipoIdentificacionService = tipoIdentificacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTipoIdentificacion() { 
        
            var response = await _tipoIdentificacionService.GetTipoIdentificacionResponse();
            if (response == null)
            {
                return NotFound(new ApiResponse<IEnumerable<TipoIdentificacionResponseDTO>>
                {

                    Success = false,
                    Message = "No existen datos",
                    Data = null

                });

            }
            return Ok(new ApiResponse<IEnumerable<TipoIdentificacionResponseDTO>>
            {
                Success = true,
                Message = "Datos encontrados",
                Data = response
            });
        }



    }
}
