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
        Task<XLWorkbook> GetReporteActosAdministrativosGeneradosService(ReportesDtoRequest request);
        Task<XLWorkbook> GetReporteSeguimientoCapacitacionesService(ReportesDtoRequest request);
        Task<XLWorkbook> GetReporteAutorizacionesCanceladasService(ReportesDtoRequest request);
        Task<XLWorkbook> GetReporteCapacitadoresAutorizadosService(ReportesDtoRequest request);
        Task<XLWorkbook> GetReporteCapacitadoresSuspendidosService(ReportesDtoRequest request);

    }
}
