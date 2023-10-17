using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class SubsanacionSolicitudDtoRequest
    {
        public int IdSubsanacion { get; set; }
        [JsonIgnore]
        public int SolicitudId { get; set; }
        [JsonIgnore]
        public DateTime DtFechaSubsanacion { get; set; } = DateTime.UtcNow.AddHours(-5);
        public string VcSubsanacion { get; set; } = string.Empty;
        /// <summary>
        /// Usuario quien realiza la subsanacion
        /// </summary>
        public string UsuarioId { get; set; } = string.Empty;
        public string VcNombreUsuario { get; set; } = string.Empty;

        /// <summary>
        /// Estado en el cual se encuentra la solicitud cuando generan la subsanacion
        /// </summary>
        [JsonIgnore]
        public int EstadoId { get; set; }
    }
}
