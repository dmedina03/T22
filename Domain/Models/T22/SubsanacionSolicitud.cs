using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class SubsanacionSolicitud
    {
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.
        public int IdSubsanacion { get; set; }
        public int SolicitudId { get; set; }
        public DateTime DtFechaSubsanacion { get; set; }
        public string VcSubsanacion { get; set; } = string.Empty;
        public Guid UsuarioId { get; set; }

        /// <summary>
        /// Nombre del usuario que realiza la observacion
        /// </summary>
        public string VcNombreUsuario { get; set; } = string.Empty;

        public int EstadoId { get; set; }
        public virtual Solicitud Solicitud { get; set; }
    }
}
