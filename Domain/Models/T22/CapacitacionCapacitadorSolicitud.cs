using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class CapacitacionCapacitadorSolicitud
    {
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.
        public int IdCapacitacionSolicitud { get; set; }
        public Guid CapacitadorId { get; set; }
        public string VcPublicoObjetivo { get; set; } = string.Empty;
        public int IntNumeroAsistentes { get; set; }
        public string VcTemaCapacitacion { get; set; } = string.Empty;  
        public string VcMetodologiaCapacitacion { get; set; } = string.Empty;
        public DateTime DtFechaCreacionCapacitacion { get; set; }
        public string VcDireccion { get; set; } = string.Empty;
        public string VcInformacionAdicional { get; set; } = string.Empty;
        public int DepartamentoId { get; set; }
        public int CiudadId { get; set; }
        public Guid? UsuarioRevisionId { get; set; }
        public bool? BlSeguimiento { get; set; }
        public virtual ICollection<HorariosCapacitacionSolicitud> HorariosCapacitacionSolicitud { get; set; }
        public virtual CapacitadorSolicitud CapacitadorSolicitud { get; set; } = new();
    }
}
