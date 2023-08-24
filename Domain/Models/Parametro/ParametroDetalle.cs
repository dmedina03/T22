using System.Numerics;

namespace Domain.Models.Parametro
{
    public class ParametroDetalle
    {
        public ParametroDetalle()
        {
            Hijos = new HashSet<ParametroDetalle>();
        }
        public long IdParametroDetalle { get; set; }


        public long? IdPadre { get; set; }

        public virtual ParametroDetalle? Padre { get; set; }
        public virtual ICollection<ParametroDetalle> Hijos { get; set; }

        public long ParametroId { get; set; }

        public Parametro? Parametro { get; set; }

        public String? VcNombre { get; set; }
            
        public String? TxDescripcion { get; set; }               

        public String? VcCodigoInterno { get; set; }

        public Decimal? DCodigoIterno { get; set; }

        public Boolean BEstado { get; set; }

        public int? RangoDesde { get; set; }

        public int? RangoHasta { get; set; }

    }
}
