using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string VcTipoEstado { get; set; }
        public string? VcDescripcion { get; set; }
        public bool BlIsEnable { get; set; }
        public virtual Solicitud Solicitud { get; set; }
    }
}
