using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class DocumentosSolicitudDtoResponse
    {
        public int IdDocumento { get; set; }
        public string VcTipoDocumento { get; set; } = string.Empty;
        public string VcPath { get; set; } = string.Empty;
        public bool? BlIsValid { get; set; }
    }
}
