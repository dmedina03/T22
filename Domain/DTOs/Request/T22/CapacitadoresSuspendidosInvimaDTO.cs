using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class CapacitadoresSuspendidosInvimaDto
    {

        public string EntidadTerritorial { get; set; } = string.Empty;
        public string FechaResolucionCancelacion { get; set; } = string.Empty;
        public string NumeroActoAdministrativoResolucion { get; set; } = string.Empty;
        public string NombreSolicitante { get; set; } = string.Empty;
        public string TipoIdentificacionSolicitante { get; set; } = string.Empty;
        public string Motivo { get; set; } = string.Empty;
        public string NombreCapacitador { get; set; } = string.Empty;
        public long NumeroIdentificacionCapacitador { get; set; } = 0;
        public string TituloProfesional { get; set; } = string.Empty;
        public string NumeroMatriculaProfesional { get; set; } = string.Empty;
        public string DireccionNotificacion { get; set; } = string.Empty;
        public long Telefono { get; set; }
        public string ManipuladorCarnes { get; set; } = string.Empty;
        public string ManipuladorLeche { get; set; } = string.Empty;
        public string ManipuladorAlimentos { get; set; } = string.Empty;


    }
}
