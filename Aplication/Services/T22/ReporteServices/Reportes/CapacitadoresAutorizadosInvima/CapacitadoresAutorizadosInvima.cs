using Aplication.Services.T22.ReporteServices.Design;
using Aplication.Utilities.Enum;
using ClosedXML.Excel;
using Domain.DTOs.Request.T22;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tsp;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.ReporteServices.Reportes.CapacitadoresAutorizadosInvima
{
    public class CapacitadoresAutorizadosInvima : ICapacitadoresAutorizadosInvima
    {
        private readonly ICapacitadorSolicitudRepository _capacitadorRepository;
        private readonly IResolucionSolicitudRepository _resolucionSolicitudRepository;
        private readonly ReporteDesign _reporteDesign;
        public CapacitadoresAutorizadosInvima(ICapacitadorSolicitudRepository capacitadorSolicitud,
            ReporteDesign reporteDesign, IResolucionSolicitudRepository resolucionSolicitudRepository)
        {
            _capacitadorRepository = capacitadorSolicitud;
            _reporteDesign = reporteDesign;
            _resolucionSolicitudRepository = resolucionSolicitudRepository;

        }


        public async Task<List<CapacitadoresAutorizadosInvimaDto>> GetInfoCapacitadoresAutorizados(ReportesDtoRequest request)
        {
            DateTime fechaDesde = Convert.ToDateTime(request.FechaDesde);
            DateTime fechaHasta = Convert.ToDateTime(request.FechaHasta);
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.
            var resoluciones = await _resolucionSolicitudRepository.GetAllAsync(x => x.FechaResolucion >= fechaDesde
                                && x.FechaResolucion <= fechaHasta,x => x.OrderByDescending(p => p.FechaResolucion),null,"Solicitud");

            string existTipoCapacitacion = "X";

            List<CapacitadoresAutorizadosInvimaDto> list = new();

            foreach (var res in resoluciones)
            {

                if (res.Solicitud.EstadoId == (int)EnumEstado.Aprobado)
                {
                    var capacitadores = await _capacitadorRepository.GetAllAsync(x => x.SolicitudId == res.SolicitudId) ;

                    foreach (var cap in capacitadores)
                    {
                        list.Add(new CapacitadoresAutorizadosInvimaDto
                        {

                            EntidadTerritorialSalud = _reporteDesign.EntidadTerritorial,//_reporteDesign.EntidadTerritorial,
                            FechaAutorizacionResolucion = res.FechaResolucion.ToString("dd/MM/yyyy"),
                            NumeroActoAdiminstrativoResolucion = res.VcNumeroResolucion,
                            NombreSolicitante = res.Solicitud.VcNombreUsuario,
                            TipoIdentificacion = res.Solicitud.VcTipoSolicitante.Contains("Natural") == true ? "Cédula Ciudadanía" : "NIT", // Resvisar este tema con pablo
                            NombreCapacitador = await _capacitadorRepository.GetNombreCapacitador(cap.IdCapacitadorSolicitud.ToString()),
                            NumeroIdentificacionCapacitador = cap.IntNumeroIdentificacion,
                            TituloProfesionalCapacitador = cap.VcTituloProfesional,
                            NumeroMatriculaProfesional = cap.vcNumeroTarjetaProfesional,
                            DireccionNotificacion = res.Solicitud.VcDireccionUsuario,
                            TelofonoCapacitador = cap.IntTelefono,
                            ManipuladorCarnes = await _reporteDesign.ExistTipoCapacitacionCarnes(cap) == true ? existTipoCapacitacion : "",
                            ManipuladorLeche = await _reporteDesign.ExistTipoCapacitacionLeche(cap) == true ? existTipoCapacitacion : "",
                            ManipuladorAlimentos = await _reporteDesign.ExistTipoCapacitacionAlimentos(cap) == true ? existTipoCapacitacion : ""

                        });
                    }
                }
            }

            return list;
        }

        public async Task<XLWorkbook> GetReporteCapacitadoresAutorizados(ReportesDtoRequest request)
        {

            XLWorkbook lWorkbook = new();
            var worksheet = lWorkbook.Worksheets.Add("Capacitadores Autorizados");
            var data = await GetInfoCapacitadoresAutorizados(request);
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

        }
        /// <summary>
        /// Metodo para dar nombre a las columnas de excel
        /// </summary>
        /// <param name="ws"></param>
        private void SetColumnNames(IXLRow ws)
        {

            ws.Cells("1:14").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            ws.Cell(1).Value = "Entidad territorial de salud";
            ws.Cell(2).Value = "Fecha de autorización";
            ws.Cell(3).Value = "Número de acto administrativo";
            ws.Cell(4).Value = "Razón social o nombre de la persona natural";
            ws.Cell(5).Value = "Tipo de identificación";
            ws.Cell(6).Value = "Nombre del capacitador";
            ws.Cell(7).Value = "Número de identificación";
            ws.Cell(8).Value = "Título profesional o tecnólogo";
            ws.Cell(9).Value = "No. de matricula profesional";
            ws.Cell(10).Value = "Dirección de notificación";
            ws.Cell(11).Value = "Télefono";
            ws.Cell(12).Value = "Manipulador de carnes y productos cárnicos comestibles";
            ws.Cell(13).Value = "Manipulador de leche cruda para consumo directo";
            ws.Cell(14).Value = "Manipulador de alimentos comercializados en vía pública";
        }
        /// <summary>
        /// Metodo para asignar valores a las celdas del excel
        /// </summary>
        /// <param name="row"></param>
        /// <param name="dto"></param>
        private void SetRowData(IXLRow row, CapacitadoresAutorizadosInvimaDto dto)
        {
            row.Style.Font.Bold = false;

            row.Cell(1).Value = dto.EntidadTerritorialSalud;
            row.Cell(2).Value = dto.FechaAutorizacionResolucion;
            row.Cell(3).Value = dto.NumeroActoAdiminstrativoResolucion;
            row.Cell(4).Value = dto.NombreSolicitante;
            row.Cell(5).Value = dto.TipoIdentificacion;
            row.Cell(6).Value = dto.NombreCapacitador;
            row.Cell(7).Value = dto.NumeroIdentificacionCapacitador;
            row.Cell(8).Value = dto.NumeroIdentificacionCapacitador;
            row.Cell(9).Value = dto.TituloProfesionalCapacitador;
            row.Cell(10).Value = dto.NumeroMatriculaProfesional;
            row.Cell(11).Value = dto.TelofonoCapacitador;
            row.Cell(12).Value = dto.ManipuladorCarnes;
            row.Cell(13).Value = dto.ManipuladorLeche;
            row.Cell(14).Value = dto.ManipuladorAlimentos;
            
        }
    }
}
