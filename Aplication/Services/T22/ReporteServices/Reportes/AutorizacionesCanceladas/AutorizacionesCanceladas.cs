using Aplication.Services.T22.ReporteServices.Design;
using Aplication.Utilities.Enum;
using ClosedXML.Excel;
using Domain.DTOs.Request.T22;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tsp;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using Persistence.Repository.Repositories.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.ReporteServices.Reportes.AutorizacionesCanceladas
{
    public class AutorizacionesCanceladas : IAutorizacionesCanceladas
    {

        private readonly ICapacitadorSolicitudRepository _capacitadorRepository;
        private readonly ReporteDesign _reporteDesign;
        private readonly ISeguimientoAuditoriaSolicitudRepository _seguimientoAuditoriaRepository;
        private readonly IResolucionSolicitudRepository _resolucionSolicitudRepository;
        public AutorizacionesCanceladas(ICapacitadorSolicitudRepository capacitadorSolicitud, 
            ReporteDesign reporteDesign, ISeguimientoAuditoriaSolicitudRepository seguimientoAuditoriaRepository,
            IResolucionSolicitudRepository resolucionSolicitudRepository)
        {
            _capacitadorRepository = capacitadorSolicitud;
            _reporteDesign = reporteDesign;
            _seguimientoAuditoriaRepository = seguimientoAuditoriaRepository;
            _resolucionSolicitudRepository = resolucionSolicitudRepository;
        }


        public async Task<List<AutorizacionesCanceladasDto>> GetInfoAutorizacionesCanceladas(ReportesDtoRequest request)
        {
            DateTime fechaDesde = Convert.ToDateTime(request.FechaDesde);
            DateTime fechaHasta = Convert.ToDateTime(request.FechaHasta);
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.
            var resoluciones = await _resolucionSolicitudRepository.GetAllAsync(x => x.FechaResolucion >= fechaDesde
                                && x.FechaResolucion <= fechaHasta, x => x.OrderByDescending(p => p.FechaResolucion), null, "Solicitud");

            List<AutorizacionesCanceladasDto> list = new();

            foreach (var res in resoluciones)
            {

                if (res.Solicitud.EstadoId == (int)EnumEstado.Cancelado)
                {
                    var capacitadores = await _capacitadorRepository.GetAllAsync(x => x.SolicitudId == res.SolicitudId);

                    var observaciones = await _seguimientoAuditoriaRepository.GetAllAsync(x => x.SolicitudId == res.SolicitudId);

                    foreach (var cap in capacitadores)
                    {
                        list.Add(new AutorizacionesCanceladasDto
                        {

                            RadicadoSolicitud = res.Solicitud.VcRadicado,
                            FechaAutorizacionResolucion = res.FechaResolucion.ToString("dd/MM/yyyy"),
                            NumeroResolucion = res.VcNumeroResolucion,
                            NombreSolicitante = res.Solicitud.VcNombreUsuario,
                            TipoIdentificacionSolicitante = res.Solicitud.VcTipoSolicitante.Contains("Natural") == true ? "Cédula Ciudadanía" : "NIT", // Resvisar este tema con pablo
                            MotivoCancelacion = _seguimientoAuditoriaRepository.ConcatObservaciones(observaciones),
                            NombreCapacitador = await _capacitadorRepository.GetNombreCapacitador(cap.IdCapacitadorSolicitud.ToString()),
                            NumeroIdentificacionCapacitador = cap.IntNumeroIdentificacion,
                            NumeroMatriculaProfesional = cap.vcNumeroTarjetaProfesional,
                            DireccionNotificacion = res.Solicitud.VcDireccionUsuario,
                            TipoAutorizacion = await _reporteDesign.GetTipoCapacitacionesByCapcitador(cap.IdCapacitadorSolicitud.ToString())

                        });
                    }
                }
            }

            return list;
        }

        public async Task<XLWorkbook> GetReporteAutorizacionesCanceladas(ReportesDtoRequest request)
        {

            XLWorkbook lWorkbook = new();
            var worksheet = lWorkbook.Worksheets.Add("Autorizaciones canceladas");
            var data = await GetInfoAutorizacionesCanceladas(request);
            int i = 2;
            SetTittle(worksheet);
            SetColumnWidth(worksheet);

            IXLRow row;
            foreach (var item in data)
            {

                row = worksheet.Row(i);

                var dato = item.GetType().GetProperties();

                _reporteDesign.StylesRows(row, dato.Count());

                SetRowData(row, item);
                i++;

            }
            return lWorkbook;
        }


        private void SetTittle(IXLWorksheet ws)
        {
            var rowOne = ws.Row(1);

            var tittle = ws.Row(rowOne.RowNumber());

            tittle.Style.Font.FontSize = 11;
            tittle.Style.Font.Bold = true;

            ws.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

            ws.Style.Alignment.WrapText = true;

            SetColumnNames(rowOne);
            SetColumnWidth(ws);
        }

        /// <summary>
        /// Método para dar anchura a las celdas
        /// </summary>
        /// <param name="ws"></param>
        private void SetColumnWidth(IXLWorksheet ws)
        {
            ws.Column(1).Width = 20;
            ws.Column(2).Width = 20;
            ws.Column(3).Width = 20;
            ws.Column(4).Width = 20;
            ws.Column(5).Width = 20;
            ws.Column(6).Width = 20;
            ws.Column(7).Width = 20;
            ws.Column(8).Width = 20;
            ws.Column(9).Width = 20;
            ws.Column(10).Width = 20;
            ws.Column(11).Width = 20;

        }
        /// <summary>
        /// Metodo para dar nombre a las columnas de excel
        /// </summary>
        /// <param name="ws"></param>
        private void SetColumnNames(IXLRow ws)
        {

            ws.Cells("1:11").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            ws.Cell(1).Value = "Id Solicitud";
            ws.Cell(2).Value = "Fecha de autorización";
            ws.Cell(3).Value = "Número de acto administrativo";
            ws.Cell(4).Value = "Razón social o nombre de la persona natural";
            ws.Cell(5).Value = "Tipo de identificación";
            ws.Cell(6).Value = "Motivo";
            ws.Cell(7).Value = "Nombre del capacitador";
            ws.Cell(8).Value = "Número de identificación";
            ws.Cell(9).Value = "No. de matricula profesional";
            ws.Cell(10).Value = "Dirección de notificación";
            ws.Cell(11).Value = "Tipo de autorización";
        }
        /// <summary>
        /// Metodo para asignar valores a las celdas del excel
        /// </summary>
        /// <param name="row"></param>
        /// <param name="dto"></param>
        private void SetRowData(IXLRow row, AutorizacionesCanceladasDto dto)
        {
            row.Style.Font.Bold = false;

            row.Cell(1).Value = dto.RadicadoSolicitud;
            row.Cell(2).Value = dto.FechaAutorizacionResolucion;
            row.Cell(3).Value = dto.NumeroResolucion;
            row.Cell(4).Value = dto.NombreSolicitante;
            row.Cell(5).Value = dto.TipoIdentificacionSolicitante;
            row.Cell(6).Value = dto.MotivoCancelacion;
            row.Cell(7).Value = dto.NombreCapacitador;
            row.Cell(8).Value = dto.NumeroIdentificacionCapacitador;
            row.Cell(9).Value = dto.NumeroMatriculaProfesional;
            row.Cell(10).Value = dto.DireccionNotificacion;
            row.Cell(11).Value = dto.TipoAutorizacion;
        }


    }
}
