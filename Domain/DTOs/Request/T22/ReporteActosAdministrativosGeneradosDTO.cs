using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class ReporteActosAdministrativosGeneradosDto
    {
        public string RadicadoSolicitud { get; set; } = string.Empty;
        public string TipoSolicitante { get; set; } = string.Empty;
        public string NombreSolicitante { get; set; } = string.Empty;
        public long NumeroIdentificacionSolicitante { get; set; }   
        public string TipoSolicitud { get; set; } = string.Empty;
        public string FechaAutorizacionResolucion { get; set; } = string.Empty;
        public string NumeroResolucion { get; set; } = string.Empty;
        public string TipoActoAdminsitrativo { get; set; } = string.Empty;
        public string FechaRadicacion { get; set; } = string.Empty;
        public string EstadoSolicitud { get; set; } = string.Empty;
        public string TipoAutorizacion { get; set; } = string.Empty;
        public string EstadoAutorizacion { get; set; } = string.Empty;
    }
}
