using Aplication.Services.Interfaces;
using Domain.DTOs.Response.Parametro;
using Domain.Models.Parametro;
using Dominio.DTOs.Response.ResponseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Parametro
{
    public interface IParametroDetalleService
    {
        Task<ResponseBase<List<ParametroDetalleDto>>> GetTipoSolicitud(string Id);
        Task<ResponseBase<List<ParametroDetalleDto>>> listarPorCodigoInterno(string codigoInterno);
        Task<ResponseBase<List<ParametroDetalleDto>>> listarPorCodigoInternoIdPadre(string codigoInterno, long idPadre);
        Task<ResponseBase<List<ParametroDetalleDto>>> GetResultadoValidacion(int SolicitudId);

    }
}
