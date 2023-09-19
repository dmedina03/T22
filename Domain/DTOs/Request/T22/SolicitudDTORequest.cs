using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class SolicitudDTORequest
    {
        public int IdSolicitud { get; set; }
        public string UsuarioId { get; set; }
        public string VcNombreUsuario { get; set; }
        public long IntNumeroIdentificacionUsuario { get; set; }
        public string VcDireccionUsuario { get; set; }
        public int TipoSolicitudId { get; set; }
        public string VcTipoSolicitante { get; set; }
        [JsonIgnore]
        public DateTime DtFechaSolicitud { get; set; } = DateTime.UtcNow.AddHours(-5);
        [JsonIgnore]
        public int? EstadoId { get; set; }
        public string? VcRadicado { get; set; } = null;
        public IEnumerable<CapacitadorSolicitudDTORequest> CapacitadorSolicitud { get; set; } = new List<CapacitadorSolicitudDTORequest>();
    }
}
