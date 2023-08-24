using Aplication.Services.T22.TipoCapacitacionServices;
using Domain.DTOs.Response.T22;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCapacitacionController : ControllerBase
    {
        private readonly ITipoCapacitacionService _tipoCapacitacionService;

        public TipoCapacitacionController(ITipoCapacitacionService tipoCapacitacionService)
        {
            _tipoCapacitacionService = tipoCapacitacionService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseBase<List<TipoCapacitacionDTOResponse>>>> GetAll()
            => await _tipoCapacitacionService.GetAll();
    }
}
