using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class CapacitadorSolicitudDtoResponse
    {
        public string IdCapacitadorSolicitud { get; set; } = string.Empty;
        public int SolicitudId { get; set; }
        public string VcPrimerNombre { get; set; } = string.Empty;
        public string VcSegundoNombre { get; set; } = string.Empty;
        public string VcPrimerApellido { get; set; } = string.Empty;
        public string VcSegundoApellido { get; set; } = string.Empty;
        public string VcTipoIdentificacion { get; set; } = string.Empty;
        public long IntNumeroIdentificacion { get; set; }   
        public string VcTituloProfesional { get; set; } = string.Empty;
        public string VcNumeroTarjetaProfesional { get; set; } = string.Empty;
        public long IntTelefono { get; set; }
        public string VcEmail { get; set; } = string.Empty;
        public List<CapacitadorTipoCapacitacionDtoResponse> CapacitadorTipoCapacitacion { get; set; } = new();
        public List<DocumentosSolicitudDtoResponse> DocumentosSolicitud { get; set; } = new();

    }
}
