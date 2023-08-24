﻿using Aplication.Services.Parametro;
using Domain.DTOs.Response.Parametro;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametroDetalleController : ControllerBase
    {

        private readonly IParametroDetalleService _parametroDetalleService;

        public ParametroDetalleController(IParametroDetalleService parametroDetalleService)
        {
            _parametroDetalleService = parametroDetalleService;
        }

        [HttpGet("TiposSolicitud/{IdUsuario}")]
        public async Task<ActionResult<ResponseBase<List<ParametroDetalleDTO>>>> GetAllRequestTypes(int IdUsuario)
            => await _parametroDetalleService.GetTipoSolicitud(IdUsuario);

        [HttpGet("PorCodigoInterno/{codigoInterno}")]
        public async Task<ActionResult<ResponseBase<List<ParametroDetalleDTO>>>> listarPorCodigoInterno(string codigoInterno)
            => await _parametroDetalleService.listarPorCodigoInterno(codigoInterno);

        [HttpGet("PorCodigoInternoIdPadre/{codigoInterno}/{idPadre}")]
        public async Task<ActionResult<ResponseBase<List<ParametroDetalleDTO>>>> listarPorCodigoInternoIdPadre(string codigoInterno, long idPadre)
            => await _parametroDetalleService.listarPorCodigoInternoIdPadre(codigoInterno,idPadre);

    }
}