using Aplication.Services.T22.ReporteServices.Design;
using Aplication.Utilities.Enum;
using ClosedXML.Excel;
using Domain.DTOs.Request.T22;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using Persistence.Repository.Repositories.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.ReporteServices.Reportes.CapacitadoresSuspendidosInvima
{
    public class CapacitadoresSuspendidosInvima : ICapacitadoresSuspendidosInivima
    {
        private readonly ICapacitadorSolicitudRepository _capacitadorRepository;
        private readonly IResolucionSolicitudRepository _resolucionSolicitudRepository;
        private readonly ISeguimientoAuditoriaSolicitudRepository _seguimientoAuditoriaSolicitudRepository;
        private readonly ReporteDesign _reporteDesign;
        public CapacitadoresSuspendidosInvima(ICapacitadorSolicitudRepository capacitadorSolicitud, ReporteDesign reporteDesign, 
            IResolucionSolicitudRepository resolucionSolicitudRepository, ISeguimientoAuditoriaSolicitudRepository seguimientoAuditoriaSolicitudRepository)
        {
            _capacitadorRepository = capacitadorSolicitud;
            _reporteDesign = reporteDesign;
            _resolucionSolicitudRepository = resolucionSolicitudRepository;
            _seguimientoAuditoriaSolicitudRepository = seguimientoAuditoriaSolicitudRepository;
        }


        public async Task<List<CapacitadoresSuspendidosInvimaDto>> GetInfoCapacitadoresSuspendidos(ReportesDtoRequest request)
        {
            DateTime fechaDesde = Convert.ToDateTime(request.FechaDesde);
            DateTime fechaHasta = Convert.ToDateTime(request.FechaHasta);
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.
            var resoluciones = await _resolucionSolicitudRepository.GetAllAsync(x => x.FechaResolucion >= fechaDesde
                                && x.FechaResolucion <= fechaHasta, x => x.OrderByDescending(p => p.FechaResolucion), null, "Solicitud");

            string existTipoCapacitacion = "X";

            List<CapacitadoresSuspendidosInvimaDto> list = new();



            foreach (var res in resoluciones)
            {
                if (res.Solicitud.EstadoId == (int)EnumEstado.CanceladoPorInclumplimiento)
                {
                    var capacitadores = await _capacitadorRepository.GetAllAsync(x => x.SolicitudId == res.SolicitudId);

                    var observaciones = await _seguimientoAuditoriaSolicitudRepository.GetAllAsync(x => x.SolicitudId == res.SolicitudId);

                    foreach (var cap in capacitadores)
                    {
                        list.Add(new CapacitadoresSuspendidosInvimaDto
                        {

                            EntidadTerritorial = _reporteDesign.EntidadTerritorial,
                            FechaResolucionCancelacion = res.FechaResolucion.ToString("dd/MM/yyyy"),
                            NumeroActoAdministrativoResolucion = res.VcNumeroResolucion,
                            NombreSolicitante = res.Solicitud.VcNombreUsuario,
                            TipoIdentificacionSolicitante = res.Solicitud.VcTipoSolicitante.Contains("Natural") == true ? "Cédula Ciudadanía" : "NIT",
                            Motivo = _seguimientoAuditoriaSolicitudRepository.ConcatObservaciones(observaciones),
                            NombreCapacitador = await _capacitadorRepository.GetNombreCapacitador(cap.IdCapacitadorSolicitud.ToString()),
                            NumeroIdentificacionCapacitador  = cap.IntNumeroIdentificacion,
                            TituloProfesional = cap.VcTituloProfesional,
                            NumeroMatriculaProfesional = cap.vcNumeroTarjetaProfesional,
                            DireccionNotificacion = res.Solicitud.VcDireccionUsuario,
                            Telefono = cap.IntTelefono,
                            ManipuladorCarnes = await _reporteDesign.ExistTipoCapacitacionCarnes(cap) == true ? existTipoCapacitacion : "",
                            ManipuladorLeche = await _reporteDesign.ExistTipoCapacitacionLeche(cap) == true ? existTipoCapacitacion : "",
                            ManipuladorAlimentos = await _reporteDesign.ExistTipoCapacitacionAlimentos(cap) == true ? existTipoCapacitacion : ""

                        });
                    }
                }
            }

            return list;
        }

        public async Task<XLWorkbook> GetReporteCapacitadoresSuspendidos(ReportesDtoRequest request)
        {

            XLWorkbook lWorkbook = new();
            var worksheet = lWorkbook.Worksheets.Add("Capacitadores Autorizados");
            var data = await GetInfoCapacitadoresSuspendidos(request);
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
            ws.Column(13).Width = 20;
            ws.Column(14).Width = 20;
            ws.Column(15).Width = 20;

        }
        /// <summary>
        /// Metodo para dar nombre a las columnas de excel
        /// </summary>
        /// <param name="ws"></param>
        private void SetColumnNames(IXLRow ws)
        {

            ws.Cells("1:15").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            ws.Cell(1).Value = "Entidad territorial de salud";
            ws.Cell(2).Value = "Fecha de cancelacion";
            ws.Cell(3).Value = "Número de acto administrativo";
            ws.Cell(4).Value = "Razón social o nombre de la persona natural";
            ws.Cell(5).Value = "Tipo de identificación";
            ws.Cell(6).Value = "Motivo";
            ws.Cell(7).Value = "Nombre del capacitador";
            ws.Cell(8).Value = "Número de identificación";
            ws.Cell(9).Value = "Título profesional o tecnólogo";
            ws.Cell(10).Value = "No. de matricula profesional";
            ws.Cell(11).Value = "Dirección de notificación";
            ws.Cell(12).Value = "Télefono";
            ws.Cell(13).Value = "Manipulador de carnes y productos cárnicos comestibles";
            ws.Cell(14).Value = "Manipulador de leche cruda para consumo directo";
            ws.Cell(15).Value = "Manipulador de alimentos comercializados en vía pública";
        }
        /// <summary>
        /// Metodo para asignar valores a las celdas del excel
        /// </summary>
        /// <param name="row"></param>
        /// <param name="dto"></param>
        private void SetRowData(IXLRow row, CapacitadoresSuspendidosInvimaDto dto)
        {
            row.Style.Font.Bold = false;

            row.Cell(1).Value = dto.EntidadTerritorial;
            row.Cell(2).Value = dto.FechaResolucionCancelacion;
            row.Cell(3).Value = dto.NumeroActoAdministrativoResolucion;
            row.Cell(4).Value = dto.NombreSolicitante;
            row.Cell(5).Value = dto.TipoIdentificacionSolicitante;
            row.Cell(6).Value = dto.Motivo;
            row.Cell(7).Value = dto.NombreCapacitador;
            row.Cell(8).Value = dto.NumeroIdentificacionCapacitador;
            row.Cell(9).Value = dto.TituloProfesional;
            row.Cell(10).Value = dto.NumeroMatriculaProfesional;
            row.Cell(11).Value = dto.DireccionNotificacion;
            row.Cell(12).Value = dto.Telefono;
            row.Cell(13).Value = dto.ManipuladorCarnes;
            row.Cell(14).Value = dto.ManipuladorLeche;
            row.Cell(15).Value = dto.ManipuladorAlimentos;

        }
    }
}
