using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class HorariosCapacitacionSolcitudDtoResponse
    {
        public int Numero { get; set; }
        public string FechaCapacitacion { get; set; } = string.Empty;
        public string HoraInicio { get; set; } = string.Empty;
        public string HoraFin { get; set; } = string.Empty; 
    }
}
