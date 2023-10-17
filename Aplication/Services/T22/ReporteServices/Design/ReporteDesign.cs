using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Services.T22.CapacitadorSolicitudServices;
using Aplication.Utilities.Enum;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Domain.Models.T22;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository.IRepositories.IT22;

namespace Aplication.Services.T22.ReporteServices.Design
{
    public class ReporteDesign
    {
        private readonly ICapacitadorSolicitudRepository? _capacitadorRepository;
        private readonly ITipoCapacitacionRepository? _tipoCapacitacionRepository;
        private readonly ICapacitadorTipoCapacitacionRepository? _capacitadorTipoCapacitacionRepository;
        private readonly int HeightRow = 20;
        public readonly string EntidadTerritorial = "SECRETARIA DISTRITAL DE SALUD BOGOTÁ D.C";
        public ReporteDesign()
        {
            
        }
        public ReporteDesign(ICapacitadorSolicitudRepository capacitadorSolicitudRepository, ITipoCapacitacionRepository tipoCapacitacionRepository,
            ICapacitadorTipoCapacitacionRepository capacitadorTipoCapacitacionRepository)
        {
            _capacitadorRepository = capacitadorSolicitudRepository;
            _tipoCapacitacionRepository = tipoCapacitacionRepository;
            _capacitadorTipoCapacitacionRepository = capacitadorTipoCapacitacionRepository;

        }

        public void StylesRows(IXLRow row, int i)
        {
            row.Height = HeightRow;
            row.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

            row.Style.Alignment.WrapText = true;

            row.Cells($"1:{i}").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
        }
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.
        public async Task<string> GetTipoCapacitacionesByCapcitador(string idCapacitador)
        {
            var capacitador = await _capacitadorRepository.GetAsync(x => x.IdCapacitadorSolicitud == Guid.Parse(idCapacitador), null,null, "CapacitadorTipoCapacitacion");

            List<string> list = new List<string>();

            foreach (var capTipoCapacitacion in capacitador.CapacitadorTipoCapacitacion)
            {
                list.Add((await _tipoCapacitacionRepository.GetAsync(x => x.IdTipoCapacitacion == capTipoCapacitacion.IdTipoCapacitacion)).VcDescripcion);
            }  

            
            list = list.Distinct().ToList();
            string retorno = string.Join(" ;",list);

            return retorno;
        }
        public async Task<string> GetTipoCapacitacionesBySolicitud(int IdSolicitud)
        {
            var capacitadores = await _capacitadorRepository.GetAllAsync(x => x.SolicitudId == IdSolicitud, null, x => x.Include(p => p.CapacitadorTipoCapacitacion));

            List<string> list = new List<string>();

            foreach (var cap in capacitadores)
            {

                foreach (var capTipoCapacitacion in cap.CapacitadorTipoCapacitacion)
                {
                    list.Add((await _tipoCapacitacionRepository.GetAsync(x => x.IdTipoCapacitacion == capTipoCapacitacion.IdTipoCapacitacion)).VcDescripcion);
                }
            }
            
            list = list.Distinct().ToList();
            string retorno = string.Join(" ;",list);

            return retorno;
        }

        public async Task<bool> ExistTipoCapacitacionCarnes(CapacitadorSolicitud capacitadorSolicitud)
        {

            var data = (await _capacitadorTipoCapacitacionRepository.GetAllAsync(x => x.IdCapacitadorSolicitud == capacitadorSolicitud.IdCapacitadorSolicitud)).Select(x=> x.IdTipoCapacitacion).ToList();

            if (data.Contains((int)EnumTipoCapacitacion.Carnes))
                return true;
            return false;
        }
        public async Task<bool> ExistTipoCapacitacionLeche(CapacitadorSolicitud capacitadorSolicitud)
        {
            var data = (await _capacitadorTipoCapacitacionRepository.GetAllAsync(x => x.IdCapacitadorSolicitud == capacitadorSolicitud.IdCapacitadorSolicitud)).Select(x => x.IdTipoCapacitacion).ToList();

            if (data.Contains((int)EnumTipoCapacitacion.Leche))
                return true;
            return false;
        }
        public async Task<bool> ExistTipoCapacitacionAlimentos(CapacitadorSolicitud capacitadorSolicitud)
        {
            var data = (await _capacitadorTipoCapacitacionRepository.GetAllAsync(x => x.IdCapacitadorSolicitud == capacitadorSolicitud.IdCapacitadorSolicitud)).Select(x => x.IdTipoCapacitacion).ToList();

            if (data.Contains((int)EnumTipoCapacitacion.Alimentos))
                return true;
            return false;
        }

    }
}
