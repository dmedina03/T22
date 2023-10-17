using Aplication.Services.T22.CapacitacionCapacitadorSolicitudServices;
using Domain.DTOs.Request.T22;
using Domain.DTOs.Response.T22;
using Domain.Models.T22;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repository.IRepositories.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacitacionCapacitadorController : ControllerBase
    {

        private readonly ICapacitacionCapacitadorService _capacitacionCapacitadorService;

        public CapacitacionCapacitadorController(ICapacitacionCapacitadorService capacitacionCapacitadorService)
        {
            _capacitacionCapacitadorService = capacitacionCapacitadorService;
        }

        [HttpGet("BandejaRegistrarCapacitacion")]
        public async Task<ActionResult<ResponseBase<List<BandejaResgistrarCapacitacionesDtoResponse>>>> BandejaCapacitaciones()
            => await _capacitacionCapacitadorService.GetBandejaRegistrarCapacitaciones();
        [HttpGet("BandejaSeguimientoCapacitacion")]
        public async Task<ActionResult<ResponseBase<List<BandejaSeguimientoCapacitacionDtoResponse>>>> BandejaSeguimientoCapacitaciones()
            => await _capacitacionCapacitadorService.GetBandejaSeguimientoCapacitaciones();
        [HttpGet("Capacitacion/{IdCapacitacionSolicitud}")]
        public async Task<ActionResult<ResponseBase<CapacitacionCapacitadorDtoResponse>>> GetById(int IdCapacitacionSolicitud)
            => await _capacitacionCapacitadorService.GetById(IdCapacitacionSolicitud);


        [HttpPost("RegistrarCapacitacion")]
        public async Task<ActionResult<ResponseBase<bool>>> CrearCapacitacion(CapacitacionCapacitadorSolicitudDtoRequest request)
            => await _capacitacionCapacitadorService.CreateAsync(request);
        [HttpPost("RevisionCapacitacion")]
        public async Task<ActionResult<ResponseBase<bool>>> RevisionCapacitacion(RevisionCapacitacionDtoRequest request)
            => await _capacitacionCapacitadorService.CreateRevisionCapacitacion(request);

    }
}
