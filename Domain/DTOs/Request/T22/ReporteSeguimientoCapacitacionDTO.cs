using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class ReporteSeguimientoCapacitacionDto
    {
        public string FechaAutorizacionResolucion { get; set; } = string.Empty;
        public string NumeroActoAdministrativoResolucion { get; set; } = string.Empty   ;
        public string NombreSolicitante { get; set; } = string.Empty;
        public string NombreCapacitador { get; set; } = string.Empty;
        public long NumeroIdentificacionCapacitador { get; set; }   
        public string PublicoObjetivo { get; set; } = string.Empty;
        public int NumeroAsistentes { get; set; }   
        public string TemaCapacitacion { get; set; } = string.Empty;
        public string Localidad { get; set; } = string.Empty;
        public string Seguimiento { get; set; } = string.Empty;
    }   
}
