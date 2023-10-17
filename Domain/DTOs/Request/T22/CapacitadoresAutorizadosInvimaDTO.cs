using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class CapacitadoresAutorizadosInvimaDto
    {

        public string EntidadTerritorialSalud { get; set; } = string.Empty;
        public string FechaAutorizacionResolucion { get; set; } = string.Empty;
        public string NumeroActoAdiminstrativoResolucion { get; set; } = string.Empty;
        public string NombreSolicitante { get; set; } = string.Empty;
        public string TipoIdentificacion { get; set; } = string.Empty;
        public string NombreCapacitador { get; set; } = string.Empty;
        public long NumeroIdentificacionCapacitador { get; set; } = 0;
        public string TituloProfesionalCapacitador { get; set; } = string.Empty;
        public string NumeroMatriculaProfesional{ get; set; } = string.Empty;
        public string DireccionNotificacion { get; set; } = string.Empty;
        public long TelofonoCapacitador { get; set; } = 0;
        public string ManipuladorCarnes { get; set; } = string.Empty;
        public string ManipuladorLeche { get; set; } = string.Empty;
        public string ManipuladorAlimentos { get; set; } = string.Empty;
    }
}
