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
    public class CapacitadorSolicitudConfig
    {
        public CapacitadorSolicitudConfig(EntityTypeBuilder<CapacitadorSolicitud> entity)
        {

            entity.ToTable("CapacitadorSolicitudes", schema: "manipalimentos");
            entity.HasKey(p => p.IdCapacitadorSolicitud);

            entity.HasOne(p => p.Solicitud)
                .WithMany(p => p.CapacitadorSolicitud)
                .HasForeignKey(p => p.SolicitudId);

            entity.HasMany(p => p.CapacitadorTipoCapacitacion)
                .WithOne(p => p.CapacitadorSolicitud)
                .HasForeignKey(p => p.IdCapacitadorSolicitud);
                

            entity.Property(p => p.SolicitudId);
            entity.Property(p => p.VcPrimerNombre).IsRequired().HasMaxLength(20);
            entity.Property(p => p.VcSegundoNombre).HasMaxLength(20);
            entity.Property(p => p.VcPrimerApellido).IsRequired().HasMaxLength(20);
            entity.Property(p => p.VcSegundoApellido).HasMaxLength(20);
            entity.Property(p => p.TipoIdentificacionId).IsRequired();
            entity.Property(p => p.IntNumeroIdentificacion).IsRequired();
            entity.Property(p => p.VcTituloProfesional).IsRequired();
            entity.Property(p => p.vcNumeroTarjetaProfesional).IsRequired();
            entity.Property(p => p.IntTelefono).IsRequired();
            entity.Property(p => p.VcEmail).IsRequired();
            entity.Property(p => p.BlIsValid);
            
        }
    }
}
