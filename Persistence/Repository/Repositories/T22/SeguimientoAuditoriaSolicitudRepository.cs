using Domain.Models.T22;
using iText.Layout.Element;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IT22;
using Persistence.Repository.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Repositories.T22
{
    public class SeguimientoAuditoriaSolicitudRepository : BaseRepository<int, SeguimientoAuditoriaSolicitud>, ISeguimientoAuditoriaSolicitudRepository
    {
        public SeguimientoAuditoriaSolicitudRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public async Task<string> ConcatObservaciones(IEnumerable<SeguimientoAuditoriaSolicitud> lista)
        {

            List<string> observaciones = new();

            foreach (var observacion in lista)
            {
                observaciones.Add(observacion.VcObservacion);
            }

            string retorno = string.Join(" ;", observaciones);

            return retorno;

        }

    }
}
