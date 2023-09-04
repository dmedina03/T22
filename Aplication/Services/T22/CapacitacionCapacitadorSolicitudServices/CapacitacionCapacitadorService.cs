using Aplication.Utilities;
using Azure;
using Domain.DTOs.Response.T22;
using Dominio.DTOs.Response.ResponseBase;
using Persistence.Repository.IRepositories.IT22;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.CapacitacionCapacitadorSolicitudServices
{
    public class CapacitacionCapacitadorService : ICapacitacionCapacitadorService
    {

        private readonly ICapacitacionCapacitadorRepository _capacitacionCapacitadorRepository;
        private readonly StoredProcedure _storeProcedure;

        public CapacitacionCapacitadorService(ICapacitacionCapacitadorRepository capacitacionCapacitadorRepository, StoredProcedure storeProcedure)
        {
            _capacitacionCapacitadorRepository = capacitacionCapacitadorRepository;
            _storeProcedure = storeProcedure;
        }

        public async Task<ResponseBase<List<BandejaResgistrarCapacitacionesDTOResponse>>> GetBandejaRegistrarCapacitaciones()
        {
            //var storedProcedure = _storeProcedure.Execute("[manipalimentos].[ObtenerSolicitudesBandejaValidador]");

            List<BandejaResgistrarCapacitacionesDTOResponse> list = new List<BandejaResgistrarCapacitacionesDTOResponse>();
            //while (storedProcedure.Read())
            //{
            //    BandejaResgistrarCapacitacionesDTOResponse dto = new BandejaResgistrarCapacitacionesDTOResponse()
            //    {
            //        IdSolicitud = Convert.ToInt32(storedProcedure["IdSolicitud"]),
            //        IdResolucionSolicitud = Convert.ToInt32(storedProcedure["IdResolucionSolicitud"]),
            //        IntNumeroResolucion = Convert.ToInt32(storedProcedure["IntNumeroResolucion"]),
            //        //FechaResolucion = Convert.ToDateTime(storedProcedure["FechaResolucion"]),
            //        TipoSolicitudId = Convert.ToInt32(storedProcedure["TipoSolicitudId"]),
            //        VcNombre = storedProcedure["VcNombre"].ToString(),
            //        BEstado = Convert.ToBoolean(storedProcedure["BEstado"]),
            //        IdDocumento = Convert.ToInt32(storedProcedure["IdDocumento"]),
            //        VcPath = storedProcedure["VcPath"].ToString(),
            //    };
            //    list.Add(dto);
            //}

            return new ResponseBase<List<BandejaResgistrarCapacitacionesDTOResponse>>(HttpStatusCode.OK,"OK",list, list.Count);
        }
        

    }
}
