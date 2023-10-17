using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.Parametro
{
    public class ParametroDetalleDto
    {
        public long IdParametroDetalle { get; set; }
        public string VcNombre { get; set; } = string.Empty;
        public string? TxDescripcion { get; set; }
        public string? VcCodigoInterno { get; set; }
        public decimal? DCodigoIterno { get; set; }
        public int? RangoDesde { get; set; }
        public int? RangoHasta { get; set; }
    }
}
