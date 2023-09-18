using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreacionProcedimientosAlmacenados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

					CREATE PROCEDURE [manipalimentos].[ObtenerSolicitudesBandejaValidador]
						@UsuarioAsignadoId uniqueidentifier = null
					AS
					BEGIN
						DECLARE @nSolicitudes int = (select COUNT(*) from manipalimentos.Solicitudes where UsuarioAsignadoId = @UsuarioAsignadoId);

						IF (@nSolicitudes > 0)
							begin
		
							SELECT S.* from manipalimentos.Solicitudes S where (S.EstadoId = 1 OR S.EstadoId = 4)
								AND (S.UsuarioAsignadoId = @UsuarioAsignadoId OR S.UsuarioAsignadoId is null);
		
							end
						ELSE
							begin
		
							SELECT S.* from manipalimentos.Solicitudes S where (S.EstadoId = 1 OR S.EstadoId = 4 OR S.EstadoId = 7)
								AND S.UsuarioAsignadoId is null;
		
							end

					END

                ");
            migrationBuilder.Sql(@"
                    
					CREATE PROCEDURE manipalimentos.ObtenerSolicitudesBandejaCoordinador
						@UsuarioAsignadoId uniqueidentifier = null
					AS
					BEGIN
						DECLARE @nSolicitudes int = (select COUNT(*) from manipalimentos.Solicitudes where UsuarioAsignadoId = @UsuarioAsignadoId);

						IF (@nSolicitudes > 0)
							begin
		
							SELECT S.* from manipalimentos.Solicitudes S where (S.EstadoId = 2 OR S.EstadoId = 5)
								AND (S.UsuarioAsignadoId = @UsuarioAsignadoId OR S.UsuarioAsignadoId is null);
		
							end
						ELSE
							begin
		
							SELECT S.* from manipalimentos.Solicitudes S where (S.EstadoId = 2 OR S.EstadoId = 5)
								AND S.UsuarioAsignadoId is null;
		
							end

					END

                ");

            migrationBuilder.Sql(@"
                    
					CREATE PROCEDURE manipalimentos.ObtenerSolicitudesBandejaSubdirector
						@UsuarioAsignadoId uniqueidentifier = null
					AS
					BEGIN
						DECLARE @nSolicitudes int = (select COUNT(*) from manipalimentos.Solicitudes where UsuarioAsignadoId = @UsuarioAsignadoId);

						IF (@nSolicitudes > 0)
							begin
		
							SELECT S.* from manipalimentos.Solicitudes S where S.EstadoId = 3
								AND (S.UsuarioAsignadoId = @UsuarioAsignadoId OR S.UsuarioAsignadoId is null);
		
							end
						ELSE
							begin
		
							SELECT S.* from manipalimentos.Solicitudes S where S.EstadoId = 3
								AND S.UsuarioAsignadoId is null;
		
							end

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
