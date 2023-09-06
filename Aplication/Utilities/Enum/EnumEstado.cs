using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Utilities.Enum
{
    public enum EnumEstado
    {
        EnRevision = 1,
        EnVerificacion  = 2,
        ParaFirma = 3,
        DevueltaPorCoordinador = 4,
        DevueltaPorSubdirector = 5,
        VencimientoDeTerminos = 6,
        Aprobado = 7,
        EnSubsanacion = 8,
        Cancelado = 9,
        Negado = 10,
        CanceladoPorInclumplimiento = 11
    }
}
