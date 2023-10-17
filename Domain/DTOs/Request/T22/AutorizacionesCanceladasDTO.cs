using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class AutorizacionesCanceladasDto
    {
        public string RadicadoSolicitud { get; set; } = string.Empty;
        public string FechaAutorizacionResolucion { get; set; } = string.Empty;
        public string NumeroResolucion { get; set; } = string.Empty;
        public string NombreSolicitante { get; set; } = string.Empty;
        public string TipoIdentificacionSolicitante { get; set; } = string.Empty;
        public string MotivoCancelacion { get; set; } = string.Empty;
        public string NombreCapacitador { get; set; } = string.Empty;
        public long NumeroIdentificacionCapacitador { get; set; } = 0;
        public string NumeroMatriculaProfesional { get; set; } = string.Empty;
        public string DireccionNotificacion { get; set; } = string.Empty;
        public string TipoAutorizacion { get; set; } = string.Empty;

    }
}
