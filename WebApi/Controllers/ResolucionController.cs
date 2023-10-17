using Aplication.Services.T22.ResolucionServices;
using Domain.DTOs.Request.T22;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.AspNetCore.Mvc;
using Domain.Models.T22;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResolucionController : ControllerBase
    {

        private readonly IResolucionService _resolucionService;

        public ResolucionController(IResolucionService resolucionService)
        {
            _resolucionService = resolucionService;
        }

        [HttpPost("obtenerResolucion")]
        public async Task<ActionResult<ResponseBase<string>>> ObtenerResolucion(PdfDtoRequest pdfDTORequest)
        {
            return await _resolucionService.GetResolucion(pdfDTORequest);
        }

        [HttpGet("obtenerPlantilla/{idPlantilla}")]
        public async Task<ActionResult<ResponseBase<FormatoPlantilla>>> ObtenerPlantilla(int idPlantilla)
        {
            return await _resolucionService.GetFormato(idPlantilla);
        }
    }
}
