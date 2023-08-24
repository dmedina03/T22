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
    public class TipoCapacitacionConfig
    {
        public TipoCapacitacionConfig(EntityTypeBuilder<TipoCapacitacion> entity)
        {
            entity.ToTable("TipoCapacitaciones");
            entity.HasKey(p => p.IdTipoCapacitacion);

            entity.HasMany(p => p.CapacitadorTipoCapacitacion)
                .WithOne(p => p.TipoCapacitacion)
                .HasForeignKey(p => p.IdTipoCapacitacion);

            entity.Property(p => p.VcDescripcion).IsRequired();
            entity.Property(p => p.BlIsEnable).IsRequired();
        }
    }
}
