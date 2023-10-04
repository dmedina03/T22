using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class CapacitacionCapacitadorSolicitudDTORequest
    {
        public int IdCapacitacionSolicitud { get; set; }
        public string CapacitadorId { get; set; }
        public string VcPublicoObjetivo { get; set; }
        public int IntNumeroAsistentes { get; set; }
        public string VcTemaCapacitacion { get; set; }
        public string VcMetodologiaCapacitacion { get; set; }
        [JsonIgnore]
        public DateTime DtFechaCreacionCapacitacion { get; set; } = DateTime.UtcNow.AddHours(-5);
        public string VcDireccion { get; set; }
        public string VcInformacionAdicional { get; set; }
        public int DepartamentoId { get; set; }
        public int CiudadId { get; set; }
        [JsonIgnore]
        public int? UsuarioRevisionId { get; set; }
        [JsonIgnore]
        public bool? BlSeguimiento { get; set; } = false;
        public List<HorariosCapacitacionSolicitudDTORequest> HorariosCapacitacionSolicitud { get; set; }
    }
}
