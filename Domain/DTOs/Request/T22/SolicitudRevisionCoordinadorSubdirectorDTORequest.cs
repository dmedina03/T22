using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class SolicitudRevisionCoordinadorSubdirectorDTORequest : SolicitudRevisionDTORequest
    {
        public bool ResultadoValidacion { get; set; }
    }
}
