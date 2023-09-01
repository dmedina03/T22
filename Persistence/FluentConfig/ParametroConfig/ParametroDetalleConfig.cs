using Domain.Models.Parametro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.FluentConfig.ParametroConfig
{
    public class ParametroDetalleConfig
    {
        public ParametroDetalleConfig(EntityTypeBuilder<ParametroDetalle> entity)
        {
            entity.ToTable("ParametroDetalle", schema: "manipalimentos");
            entity.HasKey(p => p.IdParametroDetalle);
            

            entity.HasOne(p => p.Parametro)
                  .WithMany(p => p.ParametroDetalles)

                  .HasForeignKey(p => p.ParametroId)
                  .HasConstraintName("FK_Parametro")
                  .OnDelete(DeleteBehavior.Restrict);


            entity.HasMany(e => e.Hijos)
                .WithOne(e => e.Padre) //Each comment from Replies points back to its parent
                .HasForeignKey(e => e.IdPadre);

            entity.Property(p => p.VcNombre).IsRequired();

            entity.Property(p => p.TxDescripcion).IsRequired(false);

            entity.Property(p => p.IdPadre).IsRequired(false);

            entity.Property(p => p.VcCodigoInterno).IsRequired(false).HasMaxLength(50);

            entity.Property(p => p.DCodigoIterno).IsRequired(false).HasPrecision(17, 3);

            entity.Property(p => p.BEstado).IsRequired();

            entity.Property(p => p.RangoDesde).IsRequired(false);

            entity.Property(p => p.RangoHasta).IsRequired(false);
        }
    }
}