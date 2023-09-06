using Aplication.Services.Interfaces;
using Domain.DTOs.Request.T22;
using Domain.DTOs.Response.T22;
using Dominio.DTOs.Response.ResponseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.SolicitudServices
{
    public interface ISolicitudService : ICreateService<SolicitudDTORequest>, IGetService<SolicitudDTOResponse>
    {
        /// <summary>
        /// Método para buscar las solicitudes del ciudadano logueado y también es posible por el radicado
        /// </summary>
        /// <param name="usuarioId">UsuarioId logueado</param>
        /// <param name="radicado">Radicado de la solicitud, este campo es opcional</param>
        /// <returns>Lista de solicitudes</returns>
        Task<ResponseBase<List<SolicitudBandejaCiudadanoDTOResponse>>> GetSolicitudesByRadicado(int usuarioId, string? radicado);
        /// <summary>
        /// Método que se conecta con el procedimiento almacenado para retornar las solicitudes que pertenecen al Rol validador
        /// de acuerdo a los estados "En Revision" y "Devuelto por Coordinador"
        /// </summary>
        /// <param name="UsuarioAsignadoId">Parametro opcional, el cual hace referencia al Id de algun usuario validador</param>
        /// <returns>Lista de solicitudes</returns>
        Task<ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>> GetSolicitudesBandejaValidador(int? UsuarioAsignadoId);
        /// <summary>
        /// Método que se conecta con el procedimiento almacenado para retornar las solicitudes que pertenecen al Rol Coordinador
        /// de acuerdo a los estados "En Verficacion" y "Devuelto por Subdirector"
        /// </summary>
        /// <param name="UsuarioAsignadoId">Parametro opcional, el cual hace referencia al Id de algun usuario Coordinador</param>
        /// <returns>Lista de solicitudes</returns>
        Task<ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>> GetSolicitudesBandejaCoordinador(int? UsuarioAsignadoId);
        /// <summary>
        /// Método que se conecta con el procedimiento almacenado para retornar las solicitudes que pertenecen al Rol Subdirector
        /// de acuerdo a los estados "Para Firma"
        /// </summary>
        /// <param name="UsuarioAsignadoId">Parametro opcional, el cual hace referencia al Id de algun usuario Subdirector</param>
        /// <returns>Lista de solicitudes</returns>
        Task<ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>> GetSolicitudesBandejaSubdirector(int? UsuarioAsignadoId);
        Task<ResponseBase<bool>> CreateRevisionValidador(SolicitudRevisionValidadorDTORequest request);
        Task<ResponseBase<bool>> CreateRevisionCoordinador(SolicitudRevisionCoordinadorDTORequest request);
        Task<ResponseBase<bool>> CreateRevisionSubdirector(SolicitudRevisionSubdirectorDTORequest request);

    }
}
