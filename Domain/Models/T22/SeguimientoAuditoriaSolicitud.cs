using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class SeguimientoAuditoriaSolicitud
    {
        public int IdObservacion { get; set; }
        public int SolicitudId { get; set; }
        public DateTime DtFechaObservacion { get; set; }
        public string VcObservacion { get; set; }
        public int UsuarioId { get; set; }
        public int EstadoId { get; set; }
        public virtual Solicitud Solicitud { get; set; }
    }
}
