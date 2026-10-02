using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaJCP.Application.Interfaces;

namespace PruebaTecnicaJCP.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UbicacionController : ControllerBase
    {
    

        private readonly IUbicacionService _ubicacionService;

        public UbicacionController(IUbicacionService ubicacionService)
        {
            _ubicacionService = ubicacionService;
        }



        [HttpGet("paises")]
        public async Task<IActionResult> ObtenerPaises() { 
        
            var paises= await _ubicacionService.ObtenerPaisesAsync();
            return Ok(paises);
        }

        [HttpGet("departamentos/{paisCodigo}")]
        public async Task<IActionResult> ObtenerDepartamento(short paisCodigo) { 
        
            var departamento = await _ubicacionService.ObtenerDepartamentosAsync(paisCodigo);
            return Ok(departamento);
        }

        [HttpGet("municipios/{departamentoCodigo}")]
        public async Task<IActionResult> ObtenerMunicipio(int departamentoCodigo) { 
        
            var minicipio = await _ubicacionService.ObtenerMunicipiosAsync(departamentoCodigo);
            return Ok(minicipio);
        }

    }
}
