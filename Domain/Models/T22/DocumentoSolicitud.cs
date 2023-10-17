using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class DocumentoSolicitud
    {
        public int IdDocumento { get; set; }
        public int SolicitudId { get; set; }
        public Guid UsuarioId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string VcNombreDocumento { get; set; } = string.Empty;
        public DateTime DtFechaCargue { get; set; }
        public string VcPath { get; set; } = string.Empty;
        public int IntVersion { get; set; }
        public bool? BlUsuarioVentanilla { get; set; }
        public bool? BlIsValid { get; set; }
    }
}
