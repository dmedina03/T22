using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class CapacitadorTipoCapacitacion
    {
        public int IdTipoCapacitacion { get; set; }
        public Guid IdCapacitadorSolicitud { get; set; }
        public virtual TipoCapacitacion TipoCapacitacion { get; set; }
        public virtual CapacitadorSolicitud CapacitadorSolicitud { get; set; }
    }
}
