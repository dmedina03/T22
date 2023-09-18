using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class BandejaSeguimientoCapacitacionDTOResponse
    {
        public int IdResolucionSolicitud { get; set; }
        public string IntNumeroResolucion { get; set; }
        public int IdSolicitud { get; set; }
        public string NombreCiudadanoEntidad { get; set; }
        public long IntNumeroIdentificacion { get; set; }
        public string DtFechaResolucion { get; set; }
        public bool BlEstado { get; set; }
        public int IdDocumentoSolictud { get; set; }
        public string VcPath { get; set; }
    }
}
