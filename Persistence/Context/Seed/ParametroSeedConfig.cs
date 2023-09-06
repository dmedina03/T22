using Domain.Models.Parametro;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context.Seed
{
    public class ParametroSeedConfig
    {
        public ParametroSeedConfig(EntityTypeBuilder<Parametro> entity)
        {
            entity.HasData(
                new Parametro
                {
                    //Tipo de resolucion
                    IdParametro = 1,
                    VcNombre = "Tipo resolución",
                    VcCodigoInterno = "bTipoResolucion",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                },
                new Parametro
                {
                    //Resultado de validacion
                    IdParametro = 2,
                    VcNombre = "Resultado de la validación",
                    VcCodigoInterno = "bResultadoValidacion",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                },
                new Parametro
                {
                    //Tipo de Solicitud
                    IdParametro = 3,
                    VcNombre = "Tipo de solicitud",
                    VcCodigoInterno = "bTipoSolicitud",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                });
        }
    }
}
