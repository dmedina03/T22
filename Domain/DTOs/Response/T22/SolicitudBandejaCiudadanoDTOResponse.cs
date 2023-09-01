using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class SolicitudBandejaCiudadanoDTOResponse
    {
        public int IdSolcitud { get; set; }
        public string VcRadicado { get; set; }
        public string VcNombreTramite { get; set; }
        public string DtFechaSolicitud { get; set; }
        public string VcEstado { get; set; }
    }
}
