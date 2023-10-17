using Domain.DTOs.Request.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class SolicitudDtoResponse
    {
        public int IdSolicitud { get; set; }
        public string VcRadicado { get; set; } = string.Empty;
        public string VcEstado { get; set; } = string.Empty;
        public string VcFechaSolicitud { get; set; } = string.Empty;
        public string VcTipoTramite { get; set; } = string.Empty;
        public string UsuarioId { get; set; } = string.Empty;
        public string? UsuarioAsignadoValidadorId { get; set; }
        public string? UsuarioAsignadoCoordinadorId { get; set; }
        public string? UsuarioAsignadoSubdirectorId { get; set; }
        public List<CapacitadorSolicitudDtoResponse> CapacitadoresSolicitud { get; set; } = new();
        public List<SeguimientoAuditoriaSolicitudDtoResponse>? SeguimientoAuditoriaSolicitud { get; set; }
        public List<DocumentosSolicitudDtoResponse>? DocumentosRecursoReposicion { get; set; }
        public List<ResolucionSolicitudesDTOResponse> ResolucionSolicitudes { get; set; }

    }
}
