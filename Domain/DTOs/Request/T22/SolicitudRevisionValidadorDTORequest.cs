using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class SolicitudRevisionValidadorDTORequest : SolicitudRevisionDTORequest
    {
        public int ResultadoValidacionId { get; set; }
        public SubsanacionSolicitudDTORequest? SubsanacionSolicitud { get; set; }
        public CancelacionIncumplimientoSolicitudDTORequest? CancelacionSolicitud { get; set; }

    }
}
