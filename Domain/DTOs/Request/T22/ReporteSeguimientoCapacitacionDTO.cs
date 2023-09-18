using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class ReporteSeguimientoCapacitacionDTO
    {
        public string FechaAutorizacionResolucion { get; set; }
        public string NumeroActoAdministrativoResolucion { get; set; }
        public string NombreSolicitante { get; set; }
        public string NombreCapacitador { get; set; }
        public long NumeroIdentificacionCapacitador { get; set; }
        public string PublicoObjetivo { get; set; }
        public int NumeroAsistentes { get; set; }
        public string TemaCapacitacion { get; set; }
        public string Localidad { get; set; }
        public string Seguimiento { get; set; }
    }
}
