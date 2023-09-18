using Aplication.Services.T22.ResolucionServices;
using Domain.DTOs.Request.T22;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("/obtenerResolucion")]
        public async Task<ActionResult<ResponseBase<string>>> BandejaCapacitaciones(PdfDTORequest pdfDTORequest)
        {
            return await _resolucionService.GetResolucion(pdfDTORequest);
        }
    }
}
