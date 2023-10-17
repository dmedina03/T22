using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class HorariosCapacitacionSolicitud
    {
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.
        public int IdHonorarios { get; set; }
        public int CapacitacionSolicitudId { get; set; }
        public DateTime DtFechaCapacitacion { get; set; }
        public string HoraInicio { get; set; } = string.Empty;
        public string HoraFin { get; set; } = string.Empty;
        public CapacitacionCapacitadorSolicitud CapacitacionCapacitadorSolcitud { get; set; }

    }
}
