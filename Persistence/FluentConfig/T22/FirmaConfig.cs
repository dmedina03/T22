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
    public class FirmaConfig
    {
        public FirmaConfig(EntityTypeBuilder<Firma> entity)
        {
            entity.ToTable("Firmas", schema: "manipalimentos");
            entity.HasKey(p => p.IdFirma);

            entity.Property(p => p.UsuarioId).IsRequired();
            entity.Property(p => p.VcFirma).IsRequired();
            entity.Property(p => p.VcDescripcion).IsRequired();

        }
    }
}
