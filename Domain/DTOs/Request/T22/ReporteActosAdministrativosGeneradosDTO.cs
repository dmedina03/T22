using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class ReporteActosAdministrativosGeneradosDTO
    {
        public string RadicadoSolicitud { get; set; }
        public string TipoSolicitante { get; set; }
        public string NombreSolicitante { get; set; }
        public long NumeroIdentificacionSolicitante { get; set; }
        public string TipoSolicitud { get; set; }
        public string FechaAutorizacionResolucion { get; set; }
        public string NumeroResolucion { get; set; }
        public string TipoActoAdminsitrativo { get; set; }
        public string FechaRadicacion { get; set; }
        public string EstadoSolicitud { get; set; }
        public string TipoAutorizacion { get; set; }
        public string EstadoAutorizacion { get; set; }
    }
}
