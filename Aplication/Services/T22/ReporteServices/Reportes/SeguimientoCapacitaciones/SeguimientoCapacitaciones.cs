using Aplication.Services.T22.ReporteServices.Design;
using ClosedXML.Excel;
using Domain.DTOs.Request.T22;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.ReporteServices.Reportes.SeguimientoCapacitaciones
{
    public class SeguimientoCapacitaciones : ISeguimientoCapacitaciones
    {
        private readonly ICapacitacionCapacitadorRepository _capacitacionesRepository;
        private readonly ICapacitadorSolicitudRepository _capacitadorRepository;
        private readonly IResolucionSolicitudRepository _resolucionSolicitudRepository;
        private readonly ReporteDesign _reporteDesign;
        public SeguimientoCapacitaciones(ICapacitadorSolicitudRepository capacitadorRepository, ReporteDesign reporteDesign,
            ICapacitacionCapacitadorRepository capacitacionesRepository, IResolucionSolicitudRepository resolucionSolicitudRepository)
        {
            _reporteDesign = reporteDesign;
            _capacitacionesRepository = capacitacionesRepository;
            _resolucionSolicitudRepository = resolucionSolicitudRepository;
            _capacitadorRepository = capacitadorRepository;
        }

        public async Task<List<ReporteSeguimientoCapacitacionDTO>> GetInfoSeguimientoCapacitaciones(ReportesDTORequest request)
        {
            DateTime fechaDesde = Convert.ToDateTime(request.FechaDesde);
            DateTime fechaHasta = Convert.ToDateTime(request.FechaHasta);

            var data = await _capacitacionesRepository.GetAllAsync(x => x.DtFechaCreacionCapacitacion >= fechaDesde && x.DtFechaCreacionCapacitacion <= fechaHasta, null,
                            x => x.Include(p => p.CapacitadorSolicitud.Solicitud));

            data = data.OrderByDescending(x => x.DtFechaCreacionCapacitacion).ToList();

            List<ReporteSeguimientoCapacitacionDTO> list = new();

            foreach (var item in data)
            {

                var resolucion = (await _resolucionSolicitudRepository.GetAllAsync(x => x.SolicitudId == item.CapacitadorSolicitud.SolicitudId, x => x.OrderByDescending(x => x.FechaResolucion))).FirstOrDefault();

                list.Add(new ReporteSeguimientoCapacitacionDTO
                {

                    FechaAutorizacionResolucion = resolucion.FechaResolucion.ToString("dd/MM/yyyy"),
                    NumeroActoAdministrativoResolucion = resolucion.IntNumeroResolucion.ToString("00000"),
                    NombreSolicitante = item.CapacitadorSolicitud.Solicitud.VcNombreUsuario,
                    NombreCapacitador = await _capacitadorRepository.GetNombreCapacitador(item.CapacitadorSolicitud.IdCapacitadorSolicitud.ToString()),
                    NumeroIdentificacionCapacitador = item.CapacitadorSolicitud.IntNumeroIdentificacion,
                    PublicoObjetivo = item.VcPublicoObjetivo,
                    NumeroAsistentes = item.IntNumeroAsistentes,
                    TemaCapacitacion = item.VcTemaCapacitacion,
                    Localidad = item.VcDireccion, //Revisar este tema
                    Seguimiento = item.BlSeguimiento == true ? "Si" : "No"

                });
            }
            return list;
        }

        public async Task<XLWorkbook> GetReporteActosAdministrativosGenerados(ReportesDTORequest request)
        {

            XLWorkbook lWorkbook = new();
            var worksheet = lWorkbook.Worksheets.Add("Actos administrativos generados");
            var data = await GetInfoSeguimientoCapacitaciones(request);
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


        private async void SetTittle(IXLWorksheet ws)
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
        private async void SetColumnWidth(IXLWorksheet ws)
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
        private async void SetColumnNames(IXLRow ws)
        {

            ws.Cells("1:10").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            ws.Cell(1).Value = "Fecha de autorización";
            ws.Cell(2).Value = "Número de acto administrativo";
            ws.Cell(3).Value = "Razón social o nombre de la persona natural";
            ws.Cell(4).Value = "Nombre del capacitador";
            ws.Cell(5).Value = "Numero de identificación";
            ws.Cell(6).Value = "Publico objetivo";
            ws.Cell(7).Value = "Número de asistentes";
            ws.Cell(8).Value = "Tema de la capacitación";
            ws.Cell(9).Value = "Localidad";
            ws.Cell(10).Value = "Seguimiento";
        }
        /// <summary>
        /// Metodo para asignar valores a las celdas del excel
        /// </summary>
        /// <param name="row"></param>
        /// <param name="dto"></param>
        private void SetRowData(IXLRow row, ReporteSeguimientoCapacitacionDTO dto)
        {
            row.Style.Font.Bold = false;

            row.Cell(1).Value = dto.FechaAutorizacionResolucion;
            row.Cell(2).Value = dto.NumeroActoAdministrativoResolucion;
            row.Cell(3).Value = dto.NombreSolicitante;
            row.Cell(4).Value = dto.NombreCapacitador;
            row.Cell(5).Value = dto.NumeroIdentificacionCapacitador;
            row.Cell(6).Value = dto.PublicoObjetivo;
            row.Cell(7).Value = dto.NumeroAsistentes;
            row.Cell(8).Value = dto.TemaCapacitacion;
            row.Cell(9).Value = dto.Localidad;
            row.Cell(10).Value = dto.Seguimiento;
        }

    }
}
