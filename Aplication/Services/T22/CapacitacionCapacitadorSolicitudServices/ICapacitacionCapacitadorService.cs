using Aplication.Services.Interfaces;
using Domain.DTOs.Request.T22;
using Domain.DTOs.Response.T22;
using Domain.Models.T22;
using Dominio.DTOs.Response.ResponseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.CapacitacionCapacitadorSolicitudServices
{
    public interface ICapacitacionCapacitadorService : ICreateService<CapacitacionCapacitadorSolicitudDTORequest>, IGetService<CapacitacionCapacitadorDTOResponse>
    {
        Task<ResponseBase<List<BandejaResgistrarCapacitacionesDTOResponse>>> GetBandejaRegistrarCapacitaciones();
        Task<ResponseBase<List<BandejaSeguimientoCapacitacionDTOResponse>>> GetBandejaSeguimientoCapacitaciones();
        Task<ResponseBase<bool>> CreateRevisionCapacitacion(RevisionCapacitacionDTORequest request);

    }
}
