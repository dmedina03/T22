using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class CapacitadorTipoCapacitacionDTORequest
    {
        public int IdTipoCapacitacion { get; set; }
        //[JsonIgnore]
        //public Guid IdCapacitadorSolicitud { get; set; }
        //public CapacitadorTipoCapacitacionDTORequest()
        //{
        //    IdCapacitadorSolicitud = new CapacitadorSolicitudDTORequest().IdCapacitadorSolicitud;
        //}
    }
}
