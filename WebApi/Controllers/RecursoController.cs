using Aplication.Services.T22.RecursoSolicitudServices;
using Domain.DTOs.Request.T22;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecursoController : ControllerBase
    {
        private readonly IRecursoSolicitudService _recursoService;

        public RecursoController(IRecursoSolicitudService recursoService)
        {
            _recursoService = recursoService;
        }

        [HttpPost("GenerarRecurso")]
        public async Task<ActionResult<ResponseBase<bool>>> GenerarRecurso(DocumentoSolicitudDtoRequest request)
            => await _recursoService.CreateAsync(request);

        [HttpPost("RevisionValidadorRecurso")]
        public async Task<ActionResult<ResponseBase<bool>>> RevisionRecursoValidador(RevisionRecursoSolicitudDtoRequest request)
            => await _recursoService.CreateRevisionRecursoValidador(request);
        
        [HttpPost("RevisionCoordinadorRecurso")]
        public async Task<ActionResult<ResponseBase<bool>>> VerificacionRecursoCoordinador(VerificacionAprobacionRecursoSolicitudDtoRequest request)
            => await _recursoService.CreateVerificacionRecursoCoordinador(request);

        [HttpPost("RevisionSubdirectorRecurso")]
        public async Task<ActionResult<ResponseBase<bool>>> AprobacionRecursoSubdirector(VerificacionAprobacionRecursoSolicitudDtoRequest request)
            => await _recursoService.CreateAprobacionRecursoSubdirector(request);
    }
}
