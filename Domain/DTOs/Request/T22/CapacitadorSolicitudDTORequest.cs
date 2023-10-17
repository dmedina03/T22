using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Domain.DTOs.Request.T22
{
    public class CapacitadorSolicitudDtoRequest
    {
        public Guid IdCapacitadorSolicitud { get; private set; }
        public int? SolicitudId { get; set; } = 0;
        public string VcPrimerNombre { get; set; } = string.Empty;
        public string? VcSegundoNombre { get; set; }
        public string VcPrimerApellido { get; set; } = string.Empty;
        public string? VcSegundoApellido { get; set; }
        public int TipoIdentificacionId { get; set; }
        public long IntNumeroIdentificacion { get; set; }
        public string VcTituloProfesional { get; set; } = string.Empty;
        public string VcNumeroTarjetaProfesional { get; set; } = string.Empty;
        public long IntTelefono { get; set; }
        public string VcEmail { get; set; } = string.Empty;
        [JsonIgnore]
        public bool? BlIsValid { get; set; } = null;
        public IEnumerable<CapacitadorTipoCapacitacionDtoRequest> CapacitadorTipoCapacitacion{ get; set; } = new List<CapacitadorTipoCapacitacionDtoRequest>();
        public IEnumerable<DocumentoSolicitudDtoRequest> DocumentoSolicitud { get; set; } = new List<DocumentoSolicitudDtoRequest>();

        public CapacitadorSolicitudDtoRequest()
        {
            IdCapacitadorSolicitud = Guid.NewGuid();
        }

    }
}
