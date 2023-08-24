using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class SolicitudBandejaSolicitudesDTOResponse
    {
        public int IdSolicitud { get; set; }
        public string VcRadicado { get; set; }
        public string VcNombreUsuario { get; set; }
        public long IntNumeroIdentificacionUsuario { get; set; }
        public string VcTipoSolicitud { get; set; }
        public string VcTipoSolicitante { get; set; }
        public string DtFechaSolicitud { get; set; }
        public string VcTipoEstado { get; set; }
    }
}
