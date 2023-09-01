using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionProcedimientoObtenerSolicitudesValidador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

					ALTER PROCEDURE [manipalimentos].[ObtenerSolicitudesBandejaValidador]
						@UsuarioAsignadoId int = null
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE manipalimentos.ObtenerSolicitudesBandejaValidador");
        }
    }
}
