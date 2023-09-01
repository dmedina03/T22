using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class HorariosCapacitacionSolicitud
    {
        public int IdHonorarios { get; set; }
        public int CapacitacionSolicitudId { get; set; }
        public DateTime DtFechaCapacitacion { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
    }
}
