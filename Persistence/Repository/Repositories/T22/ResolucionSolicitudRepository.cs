using Domain.Models.T22;
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
    public class ResolucionSolicitudRepository : BaseRepository<int, ResolucionSolicitud>, IResolucionSolicitudRepository
    {
        public ResolucionSolicitudRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task UpdateIsValid(int IdResolucionSolicitud)
        {
            var resolucion = await GetAsync(x => x.IdResolucionSolicitud == IdResolucionSolicitud);

            if (resolucion.BlActiva)
            {
                var fechaHoy = DateTime.UtcNow.AddHours(-5).Date;

                var diferencia = fechaHoy - resolucion.FechaResolucion;

                if (diferencia.Days >= 365)
                {
                    resolucion.BlActiva = false;

                    await UpdateAsync(resolucion);
                    await _unitOfWork.CommitAsync();
                
                }
            }
        }
    }
}
