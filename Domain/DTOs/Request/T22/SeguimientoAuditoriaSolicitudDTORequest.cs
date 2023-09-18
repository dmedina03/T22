using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class SeguimientoAuditoriaSolicitudDTORequest
    {
        public int IdObservacion { get; set; }
        [JsonIgnore]
        public int SolicitudId { get; set; }
        [JsonIgnore]
        public DateTime DtFechaObservacion { get; set; } = DateTime.UtcNow.AddHours(-5);
        public string VcObservacion { get; set; }
        /// <summary>
        /// Usuario quien realiza la observacion
        /// </summary>
        public Guid UsuarioId { get; set; }
        public string VcNombreUsuario { get; set; }

        /// <summary>
        /// Estado en el cual se encuentra la solicitud cuando se realiza la observacion
        /// </summary>
        [JsonIgnore]
        public int EstadoId { get; set; }

    }
}
