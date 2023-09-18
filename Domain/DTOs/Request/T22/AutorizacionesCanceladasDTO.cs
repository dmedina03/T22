using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class AutorizacionesCanceladasDTO
    {
        public string RadicadoSolicitud { get; set; }
        public string FechaAutorizacionResolucion { get; set; }
        public string NumeroResolucion { get; set; }
        public string NombreSolicitante { get; set; }
        public string TipoIdentificacionSolicitante { get; set; }
        public string MotivoCancelacion { get; set; }
        public string NombreCapacitador { get; set; }
        public long NumeroIdentificacionCapacitador { get; set; }
        public string NumeroMatriculaProfesional { get; set; }
        public string DireccionNotificacion { get; set; }
        public string TipoAutorizacion { get; set; }

    }
}
