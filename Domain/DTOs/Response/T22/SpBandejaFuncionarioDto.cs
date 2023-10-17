using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class SpBandejaFuncionarioDto
    {
        [Key]
        public int IdSolicitud { get; set; }
        public string VcRadicado { get; set; } = string.Empty;
        public string VcNombreUsuario { get; set; } = string.Empty;
        public long IntNumeroIdentificacionUsuario { get; set; }
        public string VcNombre { get; set; } = string.Empty;
        public string VcTipoSolicitante { get; set; }
        public string DtFechaSolicitud { get; set; }
        public string VcTipoEstado { get; set; } = string.Empty;
    }
}
