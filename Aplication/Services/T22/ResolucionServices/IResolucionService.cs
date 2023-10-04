using Dominio.DTOs.Response.ResponseBase;
using Domain.DTOs.Request.T22;
using Domain.Models.T22;

namespace Aplication.Services.T22.ResolucionServices
{
    public interface IResolucionService
    {
        Task<ResponseBase<string>> GetResolucion(PdfDTORequest requestPDFDTO);

        Task<ResponseBase<FormatoPlantilla>> GetFormato(int idFormato);
    }
}
