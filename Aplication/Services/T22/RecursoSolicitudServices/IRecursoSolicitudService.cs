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
    public interface IRecursoSolicitudService : ICreateService<DocumentoSolicitudDTORequest>
    {
        Task<ResponseBase<bool>> CreateRevisionRecursoValidador(RevisionRecursoSolicitudDTORequest request);
        Task<ResponseBase<bool>> CreateVerificacionRecursoCoordinador(VerificacionAprobacionRecursoSolicitudDTORequest request);
        Task<ResponseBase<bool>> CreateAprobacionRecursoSubdirector(VerificacionAprobacionRecursoSolicitudDTORequest request);
    }
}
