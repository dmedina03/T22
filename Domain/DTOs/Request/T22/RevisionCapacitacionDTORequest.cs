using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class RevisionCapacitacionDtoRequest
    {
        public int CapacitacionId { get; set; }
        public bool BlSeguimiento { get; set; }
        /// <summary>
        /// Usuario quien realizo el seguimiento de la capacitación
        /// </summary>
        public string UsuarioSeguimientoId { get; set; } = string.Empty;
        public List<DocumentoSolicitudDtoRequest> Documentos { get; set; } = new();
    }
}
