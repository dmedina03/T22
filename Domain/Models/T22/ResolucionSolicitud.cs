using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class ResolucionSolicitud
    {
        public int IdResolucionSolicitud { get; set; }
        public int SolicitudId { get; set; }
        public int DocumentoSolicitudId { get; set; }
        public int TipoResolucionId { get; set; }
        public DateTime FechaResolucion { get; set; }
        public long IntNumeroResolucion { get; set; }
        public bool BlActiva { get; set; }
        public Solicitud Solicitud { get; set; }
    }
}
