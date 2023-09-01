using Domain.Models.T22;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.FluentConfig.T22
{
    public class CapacitadorTipoCapacitacionConfig
    {
        public CapacitadorTipoCapacitacionConfig(EntityTypeBuilder<CapacitadorTipoCapacitacion> entity)
        {

            entity.ToTable("CapacitadorTipoCapacitaciones", schema: "manipalimentos");
            entity.HasKey(p => new { p.IdTipoCapacitacion, p.IdCapacitadorSolicitud });

                        
        }
    }
}
