using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class CancelacionSolicitud
    {
        public int IdCancelacion { get; set; }
        public int SolicitudId { get; set; }
        public DateTime DtFechaCancelacion { get; set; }
        public string VcCancelacion { get; set; }
        public int UsuarioId { get; set; }
        public int EstadoId { get; set; }
        public virtual Solicitud Solicitud { get; set; }

    }
}
