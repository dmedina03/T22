using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Utilities.Enum
{
    public enum EstadoEnum
    {
        EnRevision = 1,
        EnVerificacion  = 2,
        ParaFirma = 3,
        DevueltaPorCoordinador = 4,
        DevueltaPorSubdirector = 5,
        VencimientoDeTerminos = 6,
        Aprobado = 7,
        EnSubsanacion = 8,
        Anulado = 9,
        Negado = 10
    }
}
