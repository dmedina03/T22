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
    public class SeguimientoAuditoriaSolicitudConfig
    {
        public SeguimientoAuditoriaSolicitudConfig(EntityTypeBuilder<SeguimientoAuditoriaSolicitud> entity)
        {
            entity.ToTable("SeguimientoAuditoriaSolicitudes");
            entity.HasKey(p => p.IdObservacion);

            entity.HasOne(p => p.Solicitud)
                .WithMany(p => p.SeguimientoAuditoriaSolicitud)
                .HasForeignKey(p => p.SolicitudId);

            entity.Property(p => p.SolicitudId).IsRequired();
            entity.Property(p => p.DtFechaObservacion).IsRequired();
            entity.Property(p => p.VcObservacion).IsRequired();
            entity.Property(p => p.UsuarioId).IsRequired();
            entity.Property(p => p.EstadoId).IsRequired();
            
        }
    }
}
