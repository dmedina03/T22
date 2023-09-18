using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class HorariosCapacitacionSolcitudDTOResponse
    {
        public int Numero { get; set; }
        public string FechaCapacitacion { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
    }
}
