using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class CapacitacionCapacitadorSolicitud
    {
        public int IdCapacitacionSolicitud { get; set; }
        public Guid CapacitadorId { get; set; }
        public string VcPublicoObjetivo { get; set; }
        public int IntNumeroAsistentes { get; set; }
        public string VcTemaCapacitacion { get; set; }
        public string VcMetodologiaCapacitacion { get; set; }
        public DateTime DtFechaCreacionCapacitacion { get; set; }
        public string VcDireccion { get; set; }
        public string VcInformacionAdicional { get; set; }
        public int DepartamentoId { get; set; }
        public int CiudadId { get; set; }
        public Guid? UsuarioRevisionId { get; set; }
        public bool? BlSeguimiento { get; set; }
        public virtual ICollection<HorariosCapacitacionSolicitud> HorariosCapacitacionSolicitud { get; set; }
        public virtual CapacitadorSolicitud CapacitadorSolicitud { get; set; }
    }
}
