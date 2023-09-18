using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class CapacitadorTipoCapacitacionDTORequest
    {
        public int IdTipoCapacitacion { get; set; }
        public Guid IdCapacitadorSolicitud { get; set; }
    }
}
