using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

                    CREATE PROCEDURE [manipalimentos].[ObtenerSolicitudesBandejaValidador]
						@UsuarioAsignadoId uniqueidentifier = null
					AS
					BEGIN
								
							SELECT S.IdSolicitud,S.VcRadicado,S.VcNombreUsuario,S.IntNumeroIdentificacionUsuario,PD.VcNombre,
								S.VcTipoSolicitante,FORMAT(S.DtFechaSolicitud,'dd/MM/yyyy') AS DtFechaSolicitud,E.VcTipoEstado  
							from manipalimentos.Solicitudes S, manipalimentos.Estados E, manipalimentos.ParametroDetalle PD 
							where S.EstadoId = E.IdEstado AND S.TipoSolicitudId = PD.IdParametroDetalle 
								AND (S.EstadoId = 1 OR S.EstadoId = 4 OR S.EstadoId = 7)
								AND (S.UsuarioAsignadoValidadorId = @UsuarioAsignadoId OR S.UsuarioAsignadoValidadorId is null);

					END

                ");

            migrationBuilder.Sql(@"

                    CREATE PROCEDURE [manipalimentos].[ObtenerSolicitudesBandejaCoordinador]
						@UsuarioAsignadoId uniqueidentifier = null
					AS
					BEGIN
								
							SELECT DISTINCT S.IdSolicitud,S.VcRadicado,S.VcNombreUsuario,S.IntNumeroIdentificacionUsuario,PD.VcNombre,
								S.VcTipoSolicitante,FORMAT(S.DtFechaSolicitud,'dd/MM/yyyy') AS DtFechaSolicitud,E.VcTipoEstado  
							from manipalimentos.Solicitudes S, manipalimentos.Estados E, manipalimentos.ParametroDetalle PD 
							where S.EstadoId = E.IdEstado AND S.TipoSolicitudId = PD.IdParametroDetalle 
								AND (S.EstadoId = 2 OR S.EstadoId = 5)
								AND (S.UsuarioAsignadoCoordinadorId = @UsuarioAsignadoId OR S.UsuarioAsignadoCoordinadorId is null);

					END

                ");

            migrationBuilder.Sql(@"

                    CREATE PROCEDURE [manipalimentos].[ObtenerSolicitudesBandejaSubdirector]
						@UsuarioAsignadoId uniqueidentifier = null
					AS
					BEGIN
								
							SELECT DISTINCT S.IdSolicitud,S.VcRadicado,S.VcNombreUsuario,S.IntNumeroIdentificacionUsuario,PD.VcNombre,
								S.VcTipoSolicitante,FORMAT(S.DtFechaSolicitud,'dd/MM/yyyy') AS DtFechaSolicitud,E.VcTipoEstado  
							from manipalimentos.Solicitudes S, manipalimentos.Estados E, manipalimentos.ParametroDetalle PD 
							where S.EstadoId = E.IdEstado AND S.TipoSolicitudId = PD.IdParametroDetalle 
								AND S.EstadoId = 3
								AND (S.UsuarioAsignadoSubdirectorId = @UsuarioAsignadoId OR S.UsuarioAsignadoSubdirectorId is null);

					END

                ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE manipalimentos.ObtenerSolicitudesBandejaValidador");
            migrationBuilder.Sql("DROP PROCEDURE manipalimentos.ObtenerSolicitudesBandejaCoordinador");
            migrationBuilder.Sql("DROP PROCEDURE manipalimentos.ObtenerSolicitudesBandejaSubdirector");

        }
    }
}
