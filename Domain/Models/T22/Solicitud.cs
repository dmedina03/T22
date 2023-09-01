using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class Solicitud
    {
        public int IdSolicitud { get; set; }
        public int UsuarioId { get; set; }
        public string VcNombreUsuario { get; set; }
        public int IntNumeroIdentificacionUsuario { get; set; }
        public int TipoSolicitudId { get; set; }
        public string VcTipoSolicitante { get; set; }
        public int? UsuarioAsignadoId { get; set; }
        public DateTime DtFechaSolicitud { get; set; }
        public int EstadoId { get; set; }
        public int? ResultadoValidacionId { get; set; }
        public string? VcRadicado { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<CapacitadorSolicitud> CapacitadorSolicitud { get; set; }
        public virtual ICollection<SeguimientoAuditoriaSolicitud>? SeguimientoAuditoriaSolicitud { get; set; }
        public virtual SubsanacionSolicitud? SubsanacionSolicitud { get; set; }
        public virtual CancelacionSolicitud? CancelacionIncumplimientoSolicitud { get; set; }
    }
}
