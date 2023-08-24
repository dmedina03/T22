using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProcedimientosAlmacenados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    
					CREATE PROCEDURE dbo.ObtenerSolicitudesBandejaValidador
						@UsuarioAsignadoId int = null
					AS
					BEGIN
						DECLARE @nSolicitudes int = (select COUNT(*) from Solicitudes where UsuarioAsignadoId = @UsuarioAsignadoId);

						IF (@nSolicitudes > 0)
							begin
		
							SELECT S.* from Solicitudes S where (S.EstadoId = 1 OR S.EstadoId = 4)
								AND (S.UsuarioAsignadoId = @UsuarioAsignadoId OR S.UsuarioAsignadoId is null);
		
							end
						ELSE
							begin
		
							SELECT S.* from Solicitudes S where (S.EstadoId = 1 OR S.EstadoId = 4)
								AND S.UsuarioAsignadoId is null;
		
							end

					END

                ");

			migrationBuilder.Sql(@"
                    
					CREATE PROCEDURE dbo.ObtenerSolicitudesBandejaCoordinador
						@UsuarioAsignadoId int = null
					AS
					BEGIN
						DECLARE @nSolicitudes int = (select COUNT(*) from Solicitudes where UsuarioAsignadoId = @UsuarioAsignadoId);

						IF (@nSolicitudes > 0)
							begin
		
							SELECT S.* from Solicitudes S where (S.EstadoId = 2 OR S.EstadoId = 5)
								AND (S.UsuarioAsignadoId = @UsuarioAsignadoId OR S.UsuarioAsignadoId is null);
		
							end
						ELSE
							begin
		
							SELECT S.* from Solicitudes S where (S.EstadoId = 2 OR S.EstadoId = 5)
								AND S.UsuarioAsignadoId is null;
		
							end

					END

                ");

			migrationBuilder.Sql(@"
                    
					CREATE PROCEDURE dbo.ObtenerSolicitudesBandejaSubdirector
						@UsuarioAsignadoId int = null
					AS
					BEGIN
						DECLARE @nSolicitudes int = (select COUNT(*) from Solicitudes where UsuarioAsignadoId = @UsuarioAsignadoId);

						IF (@nSolicitudes > 0)
							begin
		
							SELECT S.* from Solicitudes S where S.EstadoId = 3
								AND (S.UsuarioAsignadoId = @UsuarioAsignadoId OR S.UsuarioAsignadoId is null);
		
							end
						ELSE
							begin
		
							SELECT S.* from Solicitudes S where S.EstadoId = 3
								AND S.UsuarioAsignadoId is null;
		
							end

					END

                ");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP PREOCEDURE dbo.ObtenerSolicitudesBandejaValidador");
			migrationBuilder.Sql("DROP PREOCEDURE dbo.ObtenerSolicitudesBandejaCoordinador");
			migrationBuilder.Sql("DROP PREOCEDURE dbo.ObtenerSolicitudesBandejaSubdirector");
        }
    }
}
