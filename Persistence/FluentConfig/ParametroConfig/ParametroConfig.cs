using Domain.Models.Parametro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.FluentConfig.ParametroConfig
{
    public class ParametroConfig
    {
        public ParametroConfig(EntityTypeBuilder<Parametro> entity)
        {
            entity.ToTable("Parametro", schema: "manipalimentos");
            entity.HasKey(p => p.IdParametro);

            entity.HasMany(p => p.ParametroDetalles)
                   .WithOne(p => p.Parametro);

            entity.Property(p => p.VcNombre).IsRequired().HasMaxLength(100);

            entity.Property(p => p.VcCodigoInterno).IsRequired().HasMaxLength(50);

            entity.Property(p => p.BEstado).IsRequired();

            entity.Property(p => p.DtFechaCreacion).IsRequired();

            entity.Property(p => p.DtFechaActualizacion).IsRequired(false);

            entity.Property(p => p.DtFechaAnulacion).IsRequired(false);

        }
    }
}