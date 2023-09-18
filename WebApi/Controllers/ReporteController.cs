using Aplication.Services.T22.ReporteServices;
using ClosedXML.Excel;
using Domain.DTOs.Request.T22;
using Domain.Models.T22;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteServices _reporteServices;

        public ReporteController(IReporteServices reporteServices)
        {
            _reporteServices = reporteServices;
        }

        [HttpGet("ActosAdministrativosGenerados/{fechaDesde}/{fechaHasta}")]
        public async Task<IActionResult> GetReporteActosAdministrativos([DataType(DataType.Date)]string fechaDesde, [DataType(DataType.Date)] string fechaHasta)
        {
            ReportesDTORequest request = new ReportesDTORequest();  
            try
            {
                request.FechaDesde = fechaDesde;
                request.FechaHasta = fechaHasta;
                var wb = await _reporteServices.GetReporteActosAdministrativosGeneradosService(request);
                if (wb is not null)
                {
                    using (var stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        byte[] content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Actos administrativos generados {DateTime.Now.ToString("dd-MM-yyyy")}.xlsx");
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {

                //_logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
        
        [HttpGet("SeguimientoCapacitaciones/{fechaDesde}/{fechaHasta}")]
        public async Task<IActionResult> GetReporteSeguimientoCapacitaciones([DataType(DataType.Date)]string fechaDesde, [DataType(DataType.Date)] string fechaHasta)
        {
            ReportesDTORequest request = new ReportesDTORequest();  
            try
            {
                request.FechaDesde = fechaDesde;
                request.FechaHasta = fechaHasta;
                var wb = await _reporteServices.GetReporteSeguimientoCapacitacionesService(request);
                if (wb is not null)
                {
                    using (var stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        byte[] content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Seguimiento capacitaciones {DateTime.Now.ToString("dd-MM-yyyy")}.xlsx");
                    }
                }
                return BadRequest();

            }
            catch (Exception ex)
            {

                //_logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
        
        [HttpGet("AutorizacionesCanceladas/{fechaDesde}/{fechaHasta}")]
        public async Task<IActionResult> GetReporteAutorizacionesCanceladas([DataType(DataType.Date)]string fechaDesde, [DataType(DataType.Date)] string fechaHasta)
        {
            ReportesDTORequest request = new ReportesDTORequest();  
            try
            {
                request.FechaDesde = fechaDesde;
                request.FechaHasta = fechaHasta;
                var wb = await _reporteServices.GetReporteAutorizacionesCanceladasService(request);
                if (wb is not null)
                {
                    using (var stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        byte[] content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Autorizaciones Canceladas {DateTime.Now.ToString("dd-MM-yyyy")}.xlsx");
                    }
                }
                return BadRequest();

            }
            catch (Exception ex)
            {

                //_logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpGet("CapacitadoresAutorizados/{fechaDesde}/{fechaHasta}")]
        public async Task<IActionResult> GetReporteCapacitadoresAutorizados([DataType(DataType.Date)]string fechaDesde, [DataType(DataType.Date)] string fechaHasta)
        {
            ReportesDTORequest request = new ReportesDTORequest();  
            try
            {
                request.FechaDesde = fechaDesde;
                request.FechaHasta = fechaHasta;
                var wb = await _reporteServices.GetReporteCapacitadoresAutorizadosService(request);
                if (wb is not null)
                {
                    using (var stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        byte[] content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Listado capacitadores autorizados INVIMA {DateTime.Now.ToString("dd-MM-yyyy")}.xlsx");
                    }
                }
                return BadRequest();

                
            }
            catch (Exception ex)
            {

                //_logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpGet("CapacitadoresSuspendidos/{fechaDesde}/{fechaHasta}")]
        public async Task<IActionResult> GetReporteCapacitadoresSuspendidos([DataType(DataType.Date)]string fechaDesde, [DataType(DataType.Date)] string fechaHasta)
        {
            ReportesDTORequest request = new ReportesDTORequest();
            try
            {
                request.FechaDesde = fechaDesde;
                request.FechaHasta = fechaHasta;
                var wb = await _reporteServices.GetReporteCapacitadoresAutorizadosService(request);
                if (wb is not null)
                {
                    using (var stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        byte[] content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Listado capacitadores suspendidos INVIMA {DateTime.Now.ToString("dd-MM-yyyy")}.xlsx");
                    }
                }
                return BadRequest();

                
            }
            catch (Exception ex)
            {

                //_logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

    }
}
