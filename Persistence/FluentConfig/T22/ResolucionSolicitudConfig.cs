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
    public class ResolucionSolicitudConfig
    {
        public ResolucionSolicitudConfig(EntityTypeBuilder<ResolucionSolicitud> entity)
        {
            entity.ToTable("ResolucionSolicitudes", schema:"manipalimentos");
            entity.HasKey(p => p.IdResolucionSolicitud);

            entity.Property(p => p.SolicitudId).IsRequired();
            entity.Property(p => p.TipoResolucionId).IsRequired();
            entity.Property(p => p.FechaResolucion).IsRequired();
            entity.Property(p => p.IntNumeroResolucion).IsRequired();
            entity.Property(p => p.BlActiva).IsRequired();
        }
    }
}
