﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response.T22
{
    public class SolicitudBandejaSolicitudesDtoResponse
    {
        public int IdSolicitud { get; set; }
        public string VcRadicado { get; set; } = string.Empty;
        public string VcNombreUsuario { get; set; } = string.Empty;
        public long IntNumeroIdentificacionUsuario { get; set; }
        public string VcTipoSolicitud { get; set; } = string.Empty;
        public string VcTipoSolicitante { get; set; } = string.Empty;
        public string DtFechaSolicitud { get; set; } = string.Empty;
        public string VcTipoEstado { get; set; } = string.Empty;
    }
}
