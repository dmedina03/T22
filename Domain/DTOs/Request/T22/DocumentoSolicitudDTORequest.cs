using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class DocumentoSolicitudDTORequest
    {
        public int IdDocumento { get; set; }
        public int? SolicitudId { get; set; } = 0;
        public string? UsuarioId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string VcNombreDocumento { get; set; }
        [JsonIgnore]
        public DateTime DtFechaCargue { get; set; } = DateTime.UtcNow.AddHours(-5);
        public string VcPath { get; set; }
        [JsonIgnore]
        public int IntVersion { get; set; } = 1;
        [JsonIgnore]
        public bool? BlIsValid { get; set; } = null;
        [JsonIgnore]
        public bool? BlUsuarioVentanilla { get; set; } = null;
    }
}
