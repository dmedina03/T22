using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class SeguimientoAuditoriaSolicitudDtoResponse
    {
        public int IdObservacion { get; set; }
        public string DtFechaObservacion { get; set; } = string.Empty;
        public string VcObservacion { get; set; } = string.Empty;
        public string UsuarioId { get; set; } = string.Empty;
        public string VcNombreUsuario { get; set; } = string.Empty;
        public string VcEstado { get; set; } = string.Empty;
    }
}
