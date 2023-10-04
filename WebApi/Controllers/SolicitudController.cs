﻿using Aplication.Services.T22.SolicitudServices;
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
        public async Task<ResponseBase<List<SolicitudBandejaCiudadanoDTOResponse>>> GetSolicitudesBandejaCiudadano(string usuarioId, string? radicado)
            => await _solicitudService.GetSolicitudesByRadicado(usuarioId, radicado);

        [HttpGet("BandejaValidador")]
        public async Task<ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>> GetSolicitudesBandejaValidador(string? UsuarioAsignadoId)
            => await _solicitudService.GetSolicitudesBandejaValidador(UsuarioAsignadoId);

        [HttpGet("BandejaCoordinador")]
        public async Task<ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>> GetSolicitudesBandejaCoordinador(string? UsuarioAsignadoId)
            => await _solicitudService.GetSolicitudesBandejaCoordinador(UsuarioAsignadoId);
        [HttpGet("BandejaSubdirector")]
        public async Task<ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>> GetSolicitudesBandejaSubdirector(string? UsuarioAsignadoId)
            => await _solicitudService.GetSolicitudesBandejaSubdirector(UsuarioAsignadoId);
        [HttpGet("{SolicitudId}")]
        public async Task<ResponseBase<SolicitudDTOResponse>> GetSolicitudById(int SolicitudId)
            => await _solicitudService.GetById(SolicitudId);
        [HttpPost("RevisionValidador")]
        public async Task<ResponseBase<bool>> RevisionValidador(SolicitudRevisionValidadorDTORequest Dto)
            => await _solicitudService.CreateRevisionValidador(Dto);
        [HttpPost("RevisionCoodinador")]
        public async Task<ResponseBase<bool>> RevisionCoordinador(SolicitudRevisionCoordinadorDTORequest Dto)
            => await _solicitudService.CreateRevisionCoordinador(Dto);
        [HttpPost("RevisionSubdirector")]
        public async Task<ResponseBase<bool>> RevisionSubdirector(SolicitudRevisionSubdirectorDTORequest Dto)
            => await _solicitudService.CreateRevisionSubdirector(Dto);
        [HttpPut("ActualizacionDocumentos/{IdSolicitud}")]
        public async Task<ResponseBase<bool>> ActualizacionDocumentos(int IdSolicitud, List<DocumentoSolicitudDTORequest> Documentos)
            => await _solicitudService.UpdateDocumentosSolicitud(IdSolicitud, Documentos);

    }
}
