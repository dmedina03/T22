using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class CapacitadorSolicitudDTOResponse
    {
        public int IdCapacitadorSolicitud { get; set; }
        public int SolicitudId { get; set; }
        public string VcPrimerNombre { get; set; }
        public string VcSegundoNombre { get; set; }
        public string VcPrimerApellido { get; set; }
        public string VcSegundoApellido { get; set; }
        public string VcTipoIdentificacion { get; set; }
        public long IntNumeroIdentificacion { get; set; }
        public string VcTituloProfesional { get; set; }
        public string vcNumeroTarjetaProfesional { get; set; }
        public long IntTelefono { get; set; }
        public string VcEmail { get; set; }
        public List<CapacitadorTipoCapacitacionDTOResponse> CapacitadorTipoCapacitacion { get; set; }
        public List<DocumentosSolicitudDTOResponse> DocumentosSolicitud { get; set; }

    }
}
