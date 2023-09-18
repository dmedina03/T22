using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class CapacitadorSolicitudDTORequest
    {
        public Guid IdCapacitadorSolicitud { get; set; } = Guid.NewGuid();
        public int? SolicitudId { get; set; } = 0;
        public string VcPrimerNombre { get; set; }
        public string? VcSegundoNombre { get; set; }
        public string VcPrimerApellido { get; set; }
        public string? VcSegundoApellido { get; set; }
        public int TipoIdentificacionId { get; set; }
        public long IntNumeroIdentificacion { get; set; }
        public string VcTituloProfesional { get; set; }
        public string vcNumeroTarjetaProfesional { get; set; }
        public long IntTelefono { get; set; }
        public string VcEmail { get; set; }
        [JsonIgnore]
        public bool? BlIsValid { get; set; } = null;
        public IEnumerable<CapacitadorTipoCapacitacionDTORequest> CapacitadorTipoCapacitacion{ get; set; } = new List<CapacitadorTipoCapacitacionDTORequest>();
        public IEnumerable<DocumentoSolicitudDTORequest> DocumentoSolicitud { get; set; } = new List<DocumentoSolicitudDTORequest>();


    }
}
