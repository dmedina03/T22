using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    [Keyless]
    public class BandejaResgistrarCapacitacionesDTOResponse
    {
        public int IdSolicitud { get; set; }
        public long IdResolucionSolicitud { get; set; }
        public long IntNumeroResolucion { get; set; }
        public string FechaResolucion { get; set; }
        public int TipoSolicitudId { get; set; }
        public string VcNombre { get; set; }
        public bool BEstado { get; set; }
        public int IdDocumento { get; set; }
        public string VcPath { get; set; }
    }
}
