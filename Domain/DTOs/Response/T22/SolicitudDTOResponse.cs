using Domain.DTOs.Request.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class SolicitudDTOResponse
    {
        public int IdSolicitud { get; set; }
        public string VcRadicado { get; set; }
        public string VcEstado { get; set; }
        public string VcFechaSolicitud { get; set; }
        public string VcTipoTramite { get; set; }
        public string? UsuarioAsignadoId { get; set; }
        public List<CapacitadorSolicitudDTOResponse> CapacitadoresSolicitud { get; set; }
        public List<SeguimientoAuditoriaSolicitudDTOResponse>? SeguimientoAuditoriaSolicitud { get; set; }


    }
}
