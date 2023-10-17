using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class SolicitudDtoRequest
    {
        public int IdSolicitud { get; set; }
        public string UsuarioId { get; set; } = string.Empty;
        public string VcNombreUsuario { get; set; } = string.Empty;
        public long IntNumeroIdentificacionUsuario { get; set; }
        public string VcDireccionUsuario { get; set; } = string.Empty;
        public int TipoSolicitudId { get; set; }
        public string VcTipoSolicitante { get; set; } = string.Empty;
        [JsonIgnore]
        public DateTime DtFechaSolicitud { get; set; } = DateTime.UtcNow.AddHours(-5);
        [JsonIgnore]
        public int? EstadoId { get; set; }
        public string? VcRadicado { get; set; } = null;
        public IEnumerable<CapacitadorSolicitudDtoRequest> CapacitadorSolicitud { get; set; } = new List<CapacitadorSolicitudDtoRequest>();
    }
}
