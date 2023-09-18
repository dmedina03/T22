using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class CapacitadoresAutorizadosInvimaDTO
    {

        public string EntidadTerritorialSalud { get; set; }
        public string FechaAutorizacionResolucion { get; set; }
        public string NumeroActoAdiminstrativoResolucion { get; set; }
        public string NombreSolicitante { get; set; }
        public string TipoIdentificacion { get; set; }
        public string NombreCapacitador { get; set; }
        public long NumeroIdentificacionCapacitador { get; set; }
        public string TituloProfesionalCapacitador { get; set; }
        public string NumeroMatriculaProfesional{ get; set; }
        public string DireccionNotificacion { get; set; }
        public long TelofonoCapacitador { get; set; }
        public string ManipuladorCarnes { get; set; }
        public string ManipuladorLeche { get; set; }
        public string ManipuladorAlimentos { get; set; }
    }
}
