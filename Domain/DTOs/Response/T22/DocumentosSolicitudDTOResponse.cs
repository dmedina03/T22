using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class DocumentosSolicitudDTOResponse
    {
        public int IdDocumento { get; set; }
        public string VcTipoDocumento { get; set; }
        public string VcPath { get; set; }
        public bool? BlIsValid { get; set; }
    }
}
