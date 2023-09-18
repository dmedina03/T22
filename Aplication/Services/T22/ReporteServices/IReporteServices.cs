using ClosedXML.Excel;
using Domain.DTOs.Request.T22;
using Dominio.DTOs.Response.ResponseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.ReporteServices
{
    public interface IReporteServices
    {
        Task<XLWorkbook> GetReporteActosAdministrativosGeneradosService(ReportesDTORequest request);
        Task<XLWorkbook> GetReporteSeguimientoCapacitacionesService(ReportesDTORequest request);
        Task<XLWorkbook> GetReporteAutorizacionesCanceladasService(ReportesDTORequest request);
        Task<XLWorkbook> GetReporteCapacitadoresAutorizadosService(ReportesDTORequest request);
        Task<XLWorkbook> GetReporteCapacitadoresSuspendidosService(ReportesDTORequest request);

    }
}
