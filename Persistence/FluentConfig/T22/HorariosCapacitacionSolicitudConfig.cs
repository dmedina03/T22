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
    public class HorariosCapacitacionSolicitudConfig
    {
        public HorariosCapacitacionSolicitudConfig(EntityTypeBuilder<HorariosCapacitacionSolicitud> entity)
        {
            entity.ToTable("HorariosCapacitacionSolicitudes", schema: "manipalimentos");
            entity.HasKey(p => p.IdHonorarios);

            entity.Property(p => p.CapacitacionSolicitudId).IsRequired();
            entity.Property(p => p.DtFechaCapacitacion).IsRequired();
            entity.Property(p => p.HoraInicio).IsRequired();
            entity.Property(p => p.HoraFin).IsRequired();
        }
    }
}
