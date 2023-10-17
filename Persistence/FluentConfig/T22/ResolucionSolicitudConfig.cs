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

            entity.HasOne(p => p.Solicitud)
                .WithMany(p => p.ResolucionSolicitud)
                .HasForeignKey(p => p.SolicitudId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(p => p.SolicitudId).IsRequired();
            entity.Property(p => p.DocumentoSolicitudId).IsRequired();
            entity.Property(p => p.TipoResolucionId).IsRequired();
            entity.Property(p => p.FechaResolucion).IsRequired();
            entity.Property(p => p.VcNumeroResolucion).IsRequired();
            entity.Property(p => p.BlActiva).IsRequired();
        }
    }
}
