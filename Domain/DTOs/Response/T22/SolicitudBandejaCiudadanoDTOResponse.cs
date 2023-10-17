using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class SolicitudBandejaCiudadanoDtoResponse
    {
        public int IdSolcitud { get; set; }
        public string VcRadicado { get; set; } = string.Empty;
        public string VcNombreTramite { get; set; } = string.Empty;
        public string DtFechaSolicitud { get; set; } = string.Empty;
        public string VcEstado { get; set; } = string.Empty;
    }
}
