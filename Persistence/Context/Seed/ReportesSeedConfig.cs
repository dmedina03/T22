using Domain.Models.Parametro;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context.Seed
{
    public class ReportesSeedConfig
    {
        public ReportesSeedConfig(EntityTypeBuilder<ParametroDetalle> entity)
        {

            entity.HasData(
                new ParametroDetalle
                {
                    IdParametroDetalle = 16,
                    ParametroId = 4,
                    VcNombre = "Actos administrativos generados",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 17,
                    ParametroId = 4,
                    VcNombre = "Autorizaciones canceladas",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 18,
                    ParametroId = 4,
                    VcNombre = "Seguimiento capacitaciones",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 19,
                    ParametroId = 4,
                    VcNombre = "Listado de capacitadores autorizados INVIMA",
                    TxDescripcion = "",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 20,
                    ParametroId = 4,
                    VcNombre = "Listado de capacitadores suspendidos INVIMA",
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
