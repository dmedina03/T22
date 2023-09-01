using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class CapacitacionCapacitadorSolicitud
    {
        public int IdCapacitacionSolicitud { get; set; }
        public int CapacitadorId { get; set; }
        public string VcPublicoObjetivo { get; set; }
        public int IntNumeroAsistentes { get; set; }
        public string VcTemaCapacitacion { get; set; }
        public string VcMetodologiaCapacitacion { get; set; }
        public DateTime DtFechaCapacitacion { get; set; }
        public int ViaPrincipalId { get; set; }
        public int IntNumeroPpl { get; set; }
        public char? CharLetraPpl { get; set; }
        public string VcBis { get; set; }
        public int? CardinalidadPplId { get; set; }
        public int ComplementoId { get; set; }
        public char? CharLetraComp { get; set; }
        public int IntNumeroComp { get; set; }
        public int IntPlaca { get; set; }
        public int CardinalidadCompId { get; set; }
        public string VcInformacionAdicional { get; set; }
        public int DepartamentoId { get; set; }
        public int CiudadId { get; set; }
        public int? UsuarioRevisionId { get; set; }
        public bool? BlSeguimiento { get; set; }
    }
}
