using Aplication.Services.T22.SolicitudServices;
using Domain.DTOs.Request.T22;
using Domain.DTOs.Response.T22;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {

        private readonly ISolicitudService _solicitudService;

        public SolicitudController(ISolicitudService solicitudService)
        {
            _solicitudService = solicitudService;
        }


        [HttpPost("CrearSolicitud")]
        public async Task<ResponseBase<bool>> CrearSolicitud(SolicitudDTORequest Dto)
            => await _solicitudService.CreateAsync(Dto);

        [HttpGet("BandejaCiudadano/{usuarioId}")]
        public async Task<ResponseBase<List<SolicitudBandejaCiudadanoDTOResponse>>> GetSolicitudesBandejaCiudadano(int usuarioId, string? radicado)
            => await _solicitudService.GetSolicitudesByRadicado(usuarioId, radicado);

        [HttpGet("BandejaValidador")]
        public async Task<object> GetSolicitudesBandejaValidador(int? UsuarioAsignadoId)
            => await _solicitudService.GetSolicitudesBandejaValidador(UsuarioAsignadoId);

        [HttpGet("BandejaCoordinador")]
        public async Task<object> GetSolicitudesBandejaCoordinador(int? UsuarioAsignadoId)
            => await _solicitudService.GetSolicitudesBandejaCoordinador(UsuarioAsignadoId);
        [HttpGet("BandejaSubdirector")]
        public async Task<object> GetSolicitudesBandejaSubdirector(int? UsuarioAsignadoId)
            => await _solicitudService.GetSolicitudesBandejaSubdirector(UsuarioAsignadoId);


    }
}
