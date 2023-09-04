using Aplication.Services.T22.CapacitacionCapacitadorSolicitudServices;
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
    public class CapacitacionController : ControllerBase
    {

        private readonly ICapacitacionCapacitadorService _capacitacionCapacitadorService;

        public CapacitacionController(ICapacitacionCapacitadorService capacitacionCapacitadorService)
        {
            _capacitacionCapacitadorService = capacitacionCapacitadorService;
        }

        [HttpGet("/Bandeja")]
        public async Task<ActionResult<ResponseBase<List<BandejaResgistrarCapacitacionesDTOResponse>>>> BandejaCapacitaciones()
        {
            return await _capacitacionCapacitadorService.GetBandejaRegistrarCapacitaciones();
        }
    }
}
