using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class SubsanacionSolicitud
    {
        public int IdSubsanacion { get; set; }
        public int SolicitudId { get; set; }
        public DateTime DtFechaSubsanacion { get; set; }
        public string VcSubsanacion { get; set; }
        public int UsuarioId { get; set; }

        /// <summary>
        /// Nombre del usuario que realiza la observacion
        /// </summary>
        public string VcNombreUsuario { get; set; }

        public int EstadoId { get; set; }
        public virtual Solicitud Solicitud { get; set; }
    }
}
