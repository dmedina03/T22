using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class DocumentoSolicitudRevisionDtoRequest
    {
        public int IdDocumento { get; set; }
        public bool BlIsValid { get; set; }
        
    }
}
