using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class SolicitudRevisionDtoRequest
    {
        public int IdSolicitud { get; set; }
        /// <summary>
        /// False si es para el de la sesion activa y True si es para un usuario externo
        /// </summary>
        public bool Asignado { get; set; }
        public Guid? UsuarioAsignadoId { get; set; }
        public List<CapacitadorSolicitudRevisionValidadorDtoRequest> CapacitadorSolicitud { get; set; } = new();
        public List<DocumentoSolicitudRevisionDtoRequest> DocumentoSolicitud { get; set; } = new List<DocumentoSolicitudRevisionDtoRequest>();
        public SeguimientoAuditoriaSolicitudDtoRequest? SeguimientoAuditoriaSolicitud { get; set; }
    }
}
