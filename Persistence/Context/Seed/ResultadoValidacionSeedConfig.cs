using Domain.Models.Parametro;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context.Seed
{
    public class ResultadoValidacionSeedConfig
    {
        public ResultadoValidacionSeedConfig(EntityTypeBuilder<Parametro> entity)
        {
            entity.HasData(
                new Parametro
                {
                    IdParametro = 2,
                    VcNombre = "Resultado de la validación",
                    VcCodigoInterno = "bResultadoValidacion",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                });
        }
        public ResultadoValidacionSeedConfig(EntityTypeBuilder<ParametroDetalle> entity)
        {
            entity.HasData(
                new ParametroDetalle
                {
                    IdParametroDetalle = 6,
                    ParametroId = 2,
                    VcNombre = "Aprobar solicitud",
                    TxDescripcion = "Aprobación",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 7,
                    ParametroId = 2,
                    VcNombre = "Cancelar solicitud",
                    TxDescripcion = "Cancelación",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 8,
                    ParametroId = 2,
                    VcNombre = "Negar solicitud",
                    TxDescripcion = "Negación",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 9,
                    ParametroId = 2,
                    VcNombre = "Para Subsanación",
                    TxDescripcion = "Subsanación",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 10,
                    ParametroId = 2,
                    VcNombre = "Cancelar por incumplimiento",
                    TxDescripcion = "Cancelación por incumplimiento",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                },
                new ParametroDetalle
                {
                    IdParametroDetalle = 11,
                    ParametroId = 2,
                    VcNombre = "Recurso",
                    TxDescripcion = "Recurso",
                    VcCodigoInterno = "",
                    DCodigoIterno = 0,
                    BEstado = true,
                    RangoDesde = 0,
                    RangoHasta = 0
                }
                );
        }

    }
}
