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
    public class EstadoConfig
    {
        public EstadoConfig(EntityTypeBuilder<Estado> entity)
        {
            entity.ToTable("Estados");
            entity.HasKey(p => p.IdEstado);

            entity.Property(p => p.VcTipoEstado).IsRequired().HasMaxLength(150);
            entity.Property(p => p.VcDescripcion).IsRequired().HasMaxLength(150);
            entity.Property(p => p.BlIsEnable).IsRequired();
        }
    }
}
