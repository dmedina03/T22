using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class CapacitadorSolicitud
    {
        public int IdCapacitadorSolicitud { get; set; }
        public int SolicitudId { get; set; }
        public string VcPrimerNombre { get; set; }
        public string VcSegundoNombre { get; set; }
        public string VcPrimerApellido { get; set; }
        public string VcSegundoApellido { get; set; }
        public int TipoIdentificacionId { get; set; }
        public int IntNumeroIdentificacion { get; set; }
        public string VcTituloProfesional { get; set; }
        public string vcNumeroTarjetaProfesional { get; set; }
        public long IntTelefono { get; set; }
        public string VcEmail { get; set; }
        public bool BlIsValid { get; set; }
        public virtual Solicitud Solicitud { get; set; }
        public virtual ICollection<CapacitadorTipoCapacitacion> CapacitadorTipoCapacitacion { get; set; }
    }
}
