using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class TipoCapacitacion
    {
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.
        public int IdTipoCapacitacion { get; set; }
        public string VcDescripcion { get; set; } = string.Empty;
        public bool BlIsEnable { get; set; }
        public virtual ICollection<CapacitadorTipoCapacitacion> CapacitadorTipoCapacitacion { get; set; }

    }
}
