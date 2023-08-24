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
        Task<ResponseBase<List<ParametroDetalleDTO>>> GetTipoSolicitud(int Id);
        Task<ResponseBase<List<ParametroDetalleDTO>>> listarPorCodigoInterno(string codigoInterno);
        Task<ResponseBase<List<ParametroDetalleDTO>>> listarPorCodigoInternoIdPadre(string codigoInterno, long idPadre);

    }
}
