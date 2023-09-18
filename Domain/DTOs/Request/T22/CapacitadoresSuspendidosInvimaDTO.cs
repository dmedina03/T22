using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class CapacitadoresSuspendidosInvimaDTO
    {

        public string EntidadTerritorial { get; set; }
        public string FechaResolucionCancelacion { get; set; }
        public string NumeroActoAdministrativoResolucion { get; set; }
        public string NombreSolicitante { get; set; }
        public string TipoIdentificacionSolicitante { get; set; }
        public string Motivo { get; set; }
        public string NombreCapacitador { get; set; }
        public long NumeroIdentificacionCapacitador { get; set; }
        public string TituloProfesional { get; set; }
        public string NumeroMatriculaProfesional { get; set; }
        public string DireccionNotificacion { get; set; }
        public long Telefono { get; set; }
        public string ManipuladorCarnes { get; set; }
        public string ManipuladorLeche { get; set; }
        public string ManipuladorAlimentos { get; set; }


    }
}
