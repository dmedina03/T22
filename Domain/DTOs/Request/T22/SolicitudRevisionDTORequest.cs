using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class SolicitudRevisionDTORequest
    {
        public int IdSolicitud { get; set; }
        public Guid? UsuarioAsignadoId { get; set; }
        public List<CapacitadorSolicitudRevisionValidadorDTORequest> CapacitadorSolicitud { get; set; } = new();
        public List<DocumentoSolicitudRevisionDTORequest> DocumentoSolicitud { get; set; } = new List<DocumentoSolicitudRevisionDTORequest>();
        public SeguimientoAuditoriaSolicitudDTORequest? SeguimientoAuditoriaSolicitud { get; set; }
    }
}
