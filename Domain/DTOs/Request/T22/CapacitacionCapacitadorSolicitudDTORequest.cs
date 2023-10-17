using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class CapacitacionCapacitadorSolicitudDtoRequest
    {
        public int IdCapacitacionSolicitud { get; set; }
        public string CapacitadorId { get; set; } = string.Empty;
        public string VcPublicoObjetivo { get; set; } = string.Empty;
        public int IntNumeroAsistentes { get; set; } = 0;
        public string VcTemaCapacitacion { get; set; } = string.Empty;
        public string VcMetodologiaCapacitacion { get; set; } = string.Empty;
        [JsonIgnore]
        public DateTime DtFechaCreacionCapacitacion { get; set; } = DateTime.UtcNow.AddHours(-5);
        public string VcDireccion { get; set; } = string.Empty;
        public string VcInformacionAdicional { get; set; } = string.Empty;
        public int DepartamentoId { get; set; }
        public int CiudadId { get; set; }
        [JsonIgnore]
        public int? UsuarioRevisionId { get; set; }
        [JsonIgnore]
        public bool? BlSeguimiento { get; set; } = false;
        public List<HorariosCapacitacionSolicitudDtoRequest> HorariosCapacitacionSolicitud { get; set; } = new();
    }
}
