using Domain.Models.Parametro;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context.Seed
{
    public class TipoResolucionSeedConfig
    {
        public TipoResolucionSeedConfig(EntityTypeBuilder<Parametro> entity)
        {
            entity.HasData(
                new Parametro
                {
                    IdParametro = 1,
                    VcNombre = "Tipo resolución",
                    VcCodigoInterno = "bTipoResolucion",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                });
        }
        public TipoResolucionSeedConfig(EntityTypeBuilder<ParametroDetalle> entity)
        {
            entity.HasData(
                new ParametroDetalle
                {
                    IdParametroDetalle = 1,
                    ParametroId = 1,
                    VcNombre = "Resolución de aprobación",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 2,
                    ParametroId = 1,
                    VcNombre = "Resolución de cancelación",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 3,
                    ParametroId = 1,
                    VcNombre = "Resolución de negación",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 4,
                    ParametroId = 1,
                    VcNombre = "Resolución de modificación",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 5,
                    ParametroId = 1,
                    VcNombre = "Resolución de cancelación por incumplimiento",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                });
        }
    }
}
