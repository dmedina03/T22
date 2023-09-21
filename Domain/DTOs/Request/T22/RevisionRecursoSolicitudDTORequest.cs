using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class RevisionRecursoSolicitudDTORequest
    {
        public int SolicitudId { get; set; }
        public DocumentoSolicitudDTORequest? RespuestaRecurso { get; set; }
        public SeguimientoAuditoriaSolicitudDTORequest? SeguimientoAuditoriaSolicitud { get; set; }
    }
}
