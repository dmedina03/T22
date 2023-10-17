using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class RevisionRecursoSolicitudDtoRequest
    {
        public int SolicitudId { get; set; }
        public DocumentoSolicitudDtoRequest? RespuestaRecurso { get; set; }
        public SeguimientoAuditoriaSolicitudDtoRequest? SeguimientoAuditoriaSolicitud { get; set; }
    }
}
