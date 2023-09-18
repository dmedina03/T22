using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class CapacitacionCapacitadorDTOResponse
    {
        public string VcNombreCapacitador { get; set; }
        public string VcPublicoObjetivo { get; set; }
        public int IntNumeroAsistentes { get; set; }
        public string VcTemaCapacitacon { get; set; }
        public string VcMetodologiaCapacitacion { get; set; }
        public List<HorariosCapacitacionSolcitudDTOResponse> HorariosCapacitacion { get; set; }
        public string VcDireccion { get; set; }
        public string VcInformacionAdicional { get; set; }
        public int DepartamentoId { get; set; }
        public int CiudadId { get; set; }
    }
}
