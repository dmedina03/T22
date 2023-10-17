using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class CapacitacionCapacitadorDtoResponse
    {
        public string VcNombreCapacitador { get; set; } = string.Empty;
        public string VcPublicoObjetivo { get; set; } = string.Empty;
        public int IntNumeroAsistentes { get; set; }        
        public string VcTemaCapacitacon { get; set; } = string.Empty;
        public string VcMetodologiaCapacitacion { get; set; } = string.Empty;
        public List<HorariosCapacitacionSolcitudDtoResponse> HorariosCapacitacion { get; set; } = new();
        public string VcDireccion { get; set; } = string.Empty;
        public string VcInformacionAdicional { get; set; } = string.Empty;
        public int DepartamentoId { get; set; }
        public int CiudadId { get; set; }
    }
}
