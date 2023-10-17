using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class SolicitudRevisionValidadorDtoRequest : SolicitudRevisionDtoRequest
    {
        public int ResultadoValidacionId { get; set; }
        public SubsanacionSolicitudDtoRequest? SubsanacionSolicitud { get; set; }
        public CancelacionIncumplimientoSolicitudDtoRequest? CancelacionSolicitud { get; set; }

    }
}
