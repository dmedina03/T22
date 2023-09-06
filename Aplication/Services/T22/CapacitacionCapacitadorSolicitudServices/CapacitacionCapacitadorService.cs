using Aplication.Utilities;
using Aplication.Utilities.Enum;
using Azure;
using Domain.DTOs.Response.T22;
using Domain.Models.T22;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.CapacitacionCapacitadorSolicitudServices
{
    public class CapacitacionCapacitadorService : ICapacitacionCapacitadorService
    {

        private readonly ICapacitacionCapacitadorRepository _capacitacionCapacitadorRepository;
        private readonly ISolicitudRespository _solicitudRespository;
        private readonly IParametroDetalleRepository _parametroDetalleRepository;
        private readonly IDocumentoSolicitudRepository _documentoSolicitudRepository;

        public CapacitacionCapacitadorService(ICapacitacionCapacitadorRepository capacitacionCapacitadorRepository, ISolicitudRespository solicitudRespository,
            IParametroDetalleRepository parametroDetalleRepository, IDocumentoSolicitudRepository documentoSolicitudRepository)
        {
            _capacitacionCapacitadorRepository = capacitacionCapacitadorRepository;
            _solicitudRespository = solicitudRespository;
            _parametroDetalleRepository = parametroDetalleRepository;
            _documentoSolicitudRepository = documentoSolicitudRepository;
        }

        public async Task<ResponseBase<List<BandejaResgistrarCapacitacionesDTOResponse>>> GetBandejaRegistrarCapacitaciones()
        {

            var Solicitudes = (await _solicitudRespository.GetAllAsync(x => x.EstadoId == (int)EnumEstado.Aprobado, null, x => x.Include(p => p.ResolucionSolicitud))).ToList();

            List<BandejaResgistrarCapacitacionesDTOResponse> list = new List<BandejaResgistrarCapacitacionesDTOResponse>();

            foreach (var solicitud in Solicitudes)
            {
                foreach (var resolucion in solicitud.ResolucionSolicitud)
                {
                    list.Add(new BandejaResgistrarCapacitacionesDTOResponse
                    {
                        IdSolicitud = solicitud.IdSolicitud,
                        IdResolucionSolicitud = resolucion.IdResolucionSolicitud,
                        IntNumeroResolucion = resolucion.IntNumeroResolucion.ToString("00000"),
                        FechaResolucion = resolucion.FechaResolucion.ToString("dd/MM/yyyy"),
                        TipoSolicitudId = solicitud.TipoSolicitudId,
                        VcNombre = await _parametroDetalleRepository.VcNombre(solicitud.TipoSolicitudId),
                        BEstado = resolucion.BlActiva,
                        IdDocumento = resolucion.DocumentoSolicitudId,
                        VcPath = (await _documentoSolicitudRepository.GetAsync(x => x.IdDocumento == resolucion.DocumentoSolicitudId)).VcPath
                    });
                }
                
            }

            return new ResponseBase<List<BandejaResgistrarCapacitacionesDTOResponse>>(HttpStatusCode.OK, "OK", list, list.Count);
        }

        ////var nombre = "manipalimentos.ObtenerSolicitudesBandejaValidador";
        //List<BandejaResgistrarCapacitacionesDTOResponse> list = new List<BandejaResgistrarCapacitacionesDTOResponse>();

        ////List<dynamic> resultado = new List<dynamic>();

        //var connString = (_unitOfWork.GetContext()).Database.GetDbConnection().ConnectionString;

        //using (var connection = new SqlConnection(connString))
        //{


        //    using (SqlCommand command = new SqlCommand("manipalimentos.ObtenerSolicitudesBandejaValidador", connection))
        //    {
        //        command.CommandType = CommandType.StoredProcedure;
        //        connection.Open();

        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                //var dataTable = new DataTable();
        //                //dataTable.Load(reader);

        //                BandejaResgistrarCapacitacionesDTOResponse bandeja = new BandejaResgistrarCapacitacionesDTOResponse();
        //                bandeja.IdSolicitud = (int)reader["IdSolicitud"];
        //                bandeja.VcNombre = reader["VcNombreUsuario"].ToString();
        //                bandeja.IdResolucionSolicitud = (int)reader["IdResolucionSolicitud"];
        //                //bandeja.TipoSolicitudId = (int)reader["PD.IdParametroDetalle"];
        //                //bandeja.IdResolucionSolicitud = (int)reader["RS.IdResolucionSolicitud"];

        //            }
        //            reader.NextResult();
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    BandejaResgistrarCapacitacionesDTOResponse bandeja = new BandejaResgistrarCapacitacionesDTOResponse();
        //                    bandeja.IdResolucionSolicitud = (int)reader["IdResolucionSolicitud"];
        //                    bandeja.FechaResolucion = (string)reader["FechaResolucion"];
        //                }
        //            }
        //        }
        //    }

        //}

    }
}
