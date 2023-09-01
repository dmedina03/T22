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
    public class FormatoPlantillaConfig
    {
        public FormatoPlantillaConfig(EntityTypeBuilder<FormatoPlantilla> entity)
        {
            entity.ToTable("FormatoPlantillas", schema: "manipalimentos");
            entity.HasKey(p => p.IdFormato);

            entity.Property(p => p.VcNombre).IsRequired();
            entity.Property(p => p.VcDescripcion).IsRequired();
            entity.Property(p => p.VcPlantilla).IsRequired();
        }
    }
}
