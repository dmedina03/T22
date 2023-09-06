using Domain.DTOs.Response.T22;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Persistence.Repository.IRepositories.IT22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.CapacitadorSolicitudServices
{
    public class CapacitadorSolicitudService : ICapacitadorSolicitudService
    {
        private readonly ICapacitadorSolicitudRepository _capacitadorSolicitudRepository;

        public CapacitadorSolicitudService(ICapacitadorSolicitudRepository capacitadorSolicitudRepository)
        {
            _capacitadorSolicitudRepository = capacitadorSolicitudRepository;
        }

        public async Task<ResponseBase<List<CapacitadorSolicitudMiniDTOResponse>>> GetListadoCapacitadores(int IdSolicitud)
        {
            var capacitadores = (await _capacitadorSolicitudRepository.GetAllAsync(x => x.SolicitudId == IdSolicitud));

            if (capacitadores is null || capacitadores.Count() == 0)
            {
                return new ResponseBase<List<CapacitadorSolicitudMiniDTOResponse>>(HttpStatusCode.NoContent, "La solicitud respondio OK, pero sin datos", null, 0);
            }

            var data = capacitadores.Select(x => new CapacitadorSolicitudMiniDTOResponse
            {
                IdCapacitadorSolicitud = x.IdCapacitadorSolicitud,
                VcNombre = $"{x.VcPrimerNombre} {x.VcSegundoNombre} {x.VcPrimerApellido} {x.VcSegundoApellido}"
            }).ToList();

            return new ResponseBase<List<CapacitadorSolicitudMiniDTOResponse>>(HttpStatusCode.OK,"OK",data,data.Count);
        }
    }
}
