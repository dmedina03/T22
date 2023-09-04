using Domain.DTOs.Response.T22;
using Dominio.DTOs.Response.ResponseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.CapacitacionCapacitadorSolicitudServices
{
    public interface ICapacitacionCapacitadorService
    {
        Task<ResponseBase<List<BandejaResgistrarCapacitacionesDTOResponse>>> GetBandejaRegistrarCapacitaciones();

    }
}
