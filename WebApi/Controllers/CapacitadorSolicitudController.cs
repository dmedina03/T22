using Aplication.Services.T22.CapacitadorSolicitudServices;
using Domain.DTOs.Response.T22;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacitadorSolicitudController : ControllerBase
    {
        private readonly ICapacitadorSolicitudService _capacitadorSolicitudService;

        public CapacitadorSolicitudController(ICapacitadorSolicitudService capacitadorSolicitudService)
        {
            _capacitadorSolicitudService = capacitadorSolicitudService;
        }

        [HttpGet("NombreCapacitadores/{IdSolicitud}")]
        public async Task<ActionResult<ResponseBase<List<CapacitadorSolicitudMiniDTOResponse>>>> GetNombreCapacitadores(int IdSolicitud)
            => await _capacitadorSolicitudService.GetListadoCapacitadores(IdSolicitud);

    }
}
