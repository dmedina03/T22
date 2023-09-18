using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class RevisionCapacitacionDTORequest
    {
        public int CapacitacionId { get; set; }
        public bool BlSeguimiento { get; set; }
        /// <summary>
        /// Usuario quien realizo el seguimiento de la capacitación
        /// </summary>
        public string UsuarioSeguimientoId { get; set; }
        public List<DocumentoSolicitudDTORequest> Documentos { get; set; } = new();
    }
}
