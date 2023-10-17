using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class SeguimientoAuditoriaSolicitud
    {
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.
        public int IdObservacion { get; set; }
        public int SolicitudId { get; set; }
        public DateTime DtFechaObservacion { get; set; }
        public string VcObservacion { get; set; } = string.Empty;
        public Guid UsuarioId { get; set; }
        public string VcNombreUsuario { get; set; } = string.Empty;
        public int EstadoId { get; set; }
        public virtual Solicitud Solicitud { get; set; }
    }
}
