using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.T22
{
    public class FormatoPlantilla
    {
        public int IdFormato { get; set; }
        public string VcNombre { get; set; } = string.Empty;
        public string VcDescripcion { get; set; } = string.Empty;
        public string VcPlantilla { get; set; } = string.Empty;
    }
}
