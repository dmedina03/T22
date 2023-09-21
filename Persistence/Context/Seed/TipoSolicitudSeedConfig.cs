using Domain.Models.Parametro;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context.Seed
{
    public class TipoSolicitudSeedConfig
    {
        public TipoSolicitudSeedConfig(EntityTypeBuilder<ParametroDetalle> entity)
        {
            entity.HasData(
                new ParametroDetalle
                {
                    IdParametroDetalle = 12,
                    ParametroId = 3,
                    VcNombre = "Primera vez",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 13,
                    ParametroId = 3,
                    VcNombre = "Renovación",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 14,
                    ParametroId = 3,
                    VcNombre = "Modificación",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
               new ParametroDetalle
               {
                   IdParametroDetalle = 15,
                   ParametroId = 3,
                   VcNombre = "Recurso de reposición",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 16,
                    ParametroId = 3,
                    VcNombre = "Cancelación",
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
