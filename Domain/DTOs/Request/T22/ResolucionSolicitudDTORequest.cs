using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class ResolucionSolicitudDtoRequest
    {
        public int IdResolucionSolicitud { get; set; }
        [JsonIgnore]
        public int TipoResolucionId { get; set; }
        [JsonIgnore]
        public DateTime FechaResolucion { get; set; } = DateTime.UtcNow.AddHours(-5);
        [JsonIgnore]
        public long IntNumeroResolucion { get; set; }
        [JsonIgnore]
        public bool BlActiva { get; set; }
        public DocumentoSolicitudDtoRequest DocumentoResolucion { get; set; } = new();
    }
}
