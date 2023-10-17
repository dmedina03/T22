using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class Firma
    {
        public int IdFirma { get; set; }
        public int UsuarioId { get; set; }
        public string VcFirma { get; set; } = string.Empty;
        public string VcDescripcion { get; set; } = string.Empty;
    }
}
