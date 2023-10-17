using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class HorariosCapacitacionSolicitudDtoRequest
    {
        [JsonIgnore]
        public int IdHonorarios { get; set; }
        [JsonIgnore]
        public int CapacitacionSolicitudId { get; set; }
        [DataType(DataType.Date)]
        public string DtFechaCapacitacion { get; set; } = string.Empty;
        public string HoraInicio { get; set; } = string.Empty;
        public string HoraFin { get; set; } = string.Empty;
    }
}
