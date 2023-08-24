using Domain.Models.T22;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context.Seed
{
    public class TipoCapacitacionSeedConfig
    {

        public TipoCapacitacionSeedConfig(EntityTypeBuilder<TipoCapacitacion> entity)
        {
            entity.HasData(new TipoCapacitacion
            {
                IdTipoCapacitacion = 1,
                VcDescripcion = "Carnes y productos cárnicos comestibles",
                BlIsEnable = true,
            });

            entity.HasData(new TipoCapacitacion
            {
                IdTipoCapacitacion = 2,
                VcDescripcion = "Leche cruda",
                BlIsEnable = true,
            });

            entity.HasData(new TipoCapacitacion
            {
                IdTipoCapacitacion = 3,
                VcDescripcion = "Alimentos en vía publica",
                BlIsEnable = true,
            });


        }

    }
}
