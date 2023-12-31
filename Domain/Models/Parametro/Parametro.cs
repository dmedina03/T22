﻿using System.Numerics;

namespace Domain.Models.Parametro
{
    public class Parametro
    {
        public long IdParametro { get; set; }

        public String? VcNombre { get; set; }

        public String? VcCodigoInterno { get; set; }

        public Boolean BEstado { get; set; }

        public DateTime DtFechaCreacion { get; set; }

        public DateTime? DtFechaActualizacion { get; set; }

        public DateTime? DtFechaAnulacion { get; set; }

        public ICollection <ParametroDetalle>? ParametroDetalles { get; set; }

    }
}
