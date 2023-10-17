using Aplication.Services.Interfaces;
using Domain.DTOs.Request.T22;
using Dominio.DTOs.Response.ResponseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.RecursoSolicitudServices
{
    public interface IRecursoSolicitudService : ICreateService<DocumentoSolicitudDtoRequest>
    {
        Task<ResponseBase<bool>> CreateRevisionRecursoValidador(RevisionRecursoSolicitudDtoRequest request);
        Task<ResponseBase<bool>> CreateVerificacionRecursoCoordinador(VerificacionAprobacionRecursoSolicitudDtoRequest request);
        Task<ResponseBase<bool>> CreateAprobacionRecursoSubdirector(VerificacionAprobacionRecursoSolicitudDtoRequest request);
    }
}
