using Aplication.Services.T22.ReporteServices.Design;
using ClosedXML.Excel;
using Domain.DTOs.Request.T22;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.ReporteServices.Reportes.ActosAdministrativos
{
    public class ActosAdministrativosGenerados : IActosAdministrativosGenerados
    {
        private readonly IParametroDetalleRepository _parametroDetalleRepository;
        private readonly IResolucionSolicitudRepository _resolucionSolicitudRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly ReporteDesign _reporteDesign;
        public ActosAdministrativosGenerados(IParametroDetalleRepository parametroDetalleRepository, IResolucionSolicitudRepository resolucionSolicitudRepository,
            IEstadoRepository estadoRepository, ReporteDesign reporteDesign)
        {
            _parametroDetalleRepository = parametroDetalleRepository;
            _resolucionSolicitudRepository = resolucionSolicitudRepository;
            _estadoRepository = estadoRepository;
            _reporteDesign = reporteDesign;

        }


        public async Task<List<ReporteActosAdministrativosGeneradosDto>> GetInfoActosAdministrativosGenerados(ReportesDtoRequest request)
        {
            DateTime fechaDesde = Convert.ToDateTime(request.FechaDesde);
            DateTime fechaHasta = Convert.ToDateTime(request.FechaHasta);

            var data = await _resolucionSolicitudRepository.GetAllAsync(x => x.FechaResolucion >= fechaDesde &&
                        x.FechaResolucion <= fechaHasta, null, x => x.Include(p => p.Solicitud));

            data = data.OrderByDescending(x => x.FechaResolucion).ToList();
            
            List<ReporteActosAdministrativosGeneradosDto> list = new();

            foreach (var item in data)
            {
                list.Add(new ReporteActosAdministrativosGeneradosDto
                {
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.
                    RadicadoSolicitud = item.Solicitud.VcRadicado,
                    TipoSolicitante = item.Solicitud.VcTipoSolicitante,
                    NombreSolicitante = item.Solicitud.VcNombreUsuario,
                    NumeroIdentificacionSolicitante = item.Solicitud.IntNumeroIdentificacionUsuario,
                    TipoSolicitud = await _parametroDetalleRepository.VcNombre(item.Solicitud.TipoSolicitudId),
                    FechaAutorizacionResolucion = item.FechaResolucion.ToString("dd/MM/yyyy"),
                    NumeroResolucion = item.VcNumeroResolucion,
                    TipoActoAdminsitrativo = await _parametroDetalleRepository.VcNombre(item.Solicitud.TipoSolicitudId),
                    FechaRadicacion = item.Solicitud.DtFechaSolicitud.ToString("dd/MM/yyyy"),
                    EstadoSolicitud = await _estadoRepository.GetNombre(item.Solicitud.EstadoId),
                    TipoAutorizacion = await _reporteDesign.GetTipoCapacitacionesBySolicitud(item.SolicitudId),
                    EstadoAutorizacion = item.BlActiva ? "Vigente" : "Cancelada"

                });
            }
            return list;
        }

        public async Task<XLWorkbook> GetReporteActosAdministrativosGenerados(ReportesDtoRequest request)
        {

            XLWorkbook lWorkbook = new();
            var worksheet = lWorkbook.Worksheets.Add("Actos administrativos generados");
            var data = await GetInfoActosAdministrativosGenerados(request);
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
            ws.Column(12).Width = 20;

        }
        /// <summary>
        /// Metodo para dar nombre a las columnas de excel
        /// </summary>
        /// <param name="ws"></param>
        private void SetColumnNames(IXLRow ws)
        {

            ws.Cells("1:12").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            ws.Cell(1).Value = "Id Solicitud";
            ws.Cell(2).Value = "Tipo Solicitante";
            ws.Cell(3).Value = "Nombre del solicitante";
            ws.Cell(4).Value = "No. Identificacion";
            ws.Cell(5).Value = "Tipo de solicitud";
            ws.Cell(6).Value = "Fecha de autorización";
            ws.Cell(7).Value = "Numero de acto administrativo";
            ws.Cell(8).Value = "Tipo de acto administrativo";
            ws.Cell(9).Value = "Fecha de radicación";
            ws.Cell(10).Value = "Estado de la solicitud";
            ws.Cell(11).Value = "Tipo de autorización";
            ws.Cell(12).Value = "Estado de la autorización";
        }
        /// <summary>
        /// Metodo para asignar valores a las celdas del excel
        /// </summary>
        /// <param name="row"></param>
        /// <param name="dto"></param>
        private void SetRowData(IXLRow row, ReporteActosAdministrativosGeneradosDto dto)
        {
            row.Style.Font.Bold = false;

            row.Cell(1).Value = dto.RadicadoSolicitud;
            row.Cell(2).Value = dto.TipoSolicitante;
            row.Cell(3).Value = dto.NombreSolicitante;
            row.Cell(4).Value = dto.NumeroIdentificacionSolicitante;
            row.Cell(5).Value = dto.TipoSolicitud;
            row.Cell(6).Value = dto.FechaAutorizacionResolucion;
            row.Cell(7).Value = dto.NumeroResolucion;
            row.Cell(8).Value = dto.TipoActoAdminsitrativo;
            row.Cell(9).Value = dto.FechaRadicacion;
            row.Cell(10).Value = dto.EstadoSolicitud;
            row.Cell(11).Value = dto.TipoAutorizacion;
            row.Cell(12).Value = dto.EstadoAutorizacion;
        }


    }
}
