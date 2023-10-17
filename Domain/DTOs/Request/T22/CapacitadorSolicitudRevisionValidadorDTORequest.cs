using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class CapacitadorSolicitudRevisionValidadorDtoRequest
    {
        public string IdCapacitadorSolicitud { get; set; } = string.Empty;
        public bool BlIsValid { get; set; }

    }
}
