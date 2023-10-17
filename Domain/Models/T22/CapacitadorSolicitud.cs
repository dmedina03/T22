using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class CapacitadorSolicitud
    {
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.
        public Guid IdCapacitadorSolicitud { get; set; }
        public int SolicitudId { get; set; }
        public string VcPrimerNombre { get; set; } = string.Empty;
        public string VcSegundoNombre { get; set; } = string.Empty;
        public string VcPrimerApellido { get; set; } = string.Empty;
        public string VcSegundoApellido { get; set; } = string.Empty;
        public int TipoIdentificacionId { get; set; }
        public long IntNumeroIdentificacion { get; set; }
        public string VcTituloProfesional { get; set; } = string.Empty;
        public string vcNumeroTarjetaProfesional { get; set; } = string.Empty;
        public long IntTelefono { get; set; }
        public string VcEmail { get; set; } = string.Empty;
        public bool BlIsValid { get; set; }
        public virtual Solicitud Solicitud { get; set; }
        public virtual ICollection<CapacitadorTipoCapacitacion> CapacitadorTipoCapacitacion { get; set; }
        public virtual ICollection<CapacitacionCapacitadorSolicitud> CapacitacionCapacitador { get; set; }
    }
}
