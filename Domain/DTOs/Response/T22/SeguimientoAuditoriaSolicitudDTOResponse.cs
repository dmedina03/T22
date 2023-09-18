using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class SeguimientoAuditoriaSolicitudDTOResponse
    {
        public int IdObservacion { get; set; }
        public string DtFechaObservacion { get; set; }
        public string VcObservacion { get; set; }
        public string UsuarioId { get; set; }
        public string VcNombreUsuario { get; set; }
        public string VcEstado { get; set; }
    }
}
