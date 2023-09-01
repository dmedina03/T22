using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EsquemaRealizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "manipalimentos");

            migrationBuilder.RenameTable(
                name: "TipoCapacitaciones",
                newName: "TipoCapacitaciones",
                newSchema: "manipalimentos");

            migrationBuilder.RenameTable(
                name: "Solicitudes",
                newName: "Solicitudes",
                newSchema: "manipalimentos");

            migrationBuilder.RenameTable(
                name: "SeguimientoAuditoriaSolicitudes",
                newName: "SeguimientoAuditoriaSolicitudes",
                newSchema: "manipalimentos");

            migrationBuilder.RenameTable(
                name: "ParametroDetalle",
                newName: "ParametroDetalle",
                newSchema: "manipalimentos");

            migrationBuilder.RenameTable(
                name: "Parametro",
                newName: "Parametro",
                newSchema: "manipalimentos");

            migrationBuilder.RenameTable(
                name: "Estados",
                newName: "Estados",
                newSchema: "manipalimentos");

            migrationBuilder.RenameTable(
                name: "DocumentoSolicitudes",
                newName: "DocumentoSolicitudes",
                newSchema: "manipalimentos");

            migrationBuilder.RenameTable(
                name: "CapacitadorTipoCapacitaciones",
                newName: "CapacitadorTipoCapacitaciones",
                newSchema: "manipalimentos");

            migrationBuilder.RenameTable(
                name: "CapacitadorSolicitudes",
                newName: "CapacitadorSolicitudes",
                newSchema: "manipalimentos");

            migrationBuilder.CreateTable(
                name: "CancelacionSolicitudes",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdCancelacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    DtFechaCancelacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VcCancelacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelacionSolicitudes", x => x.IdCancelacion);
                });

            migrationBuilder.CreateTable(
                name: "CapacitacionCapacitadorSolicitudes",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdCapacitacionSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacitadorId = table.Column<int>(type: "int", nullable: false),
                    VcPublicoObjetivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntNumeroAsistentes = table.Column<int>(type: "int", nullable: false),
                    VcTemaCapacitacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcMetodologiaCapacitacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtFechaCapacitacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViaPrincipalId = table.Column<int>(type: "int", nullable: false),
                    IntNumeroPpl = table.Column<int>(type: "int", nullable: false),
                    CharLetraPpl = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    VcBis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardinalidadPplId = table.Column<int>(type: "int", nullable: true),
                    ComplementoId = table.Column<int>(type: "int", nullable: false),
                    CharLetraComp = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    IntNumeroComp = table.Column<int>(type: "int", nullable: false),
                    IntPlaca = table.Column<int>(type: "int", nullable: false),
                    CardinalidadCompId = table.Column<int>(type: "int", nullable: false),
                    VcInformacionAdicional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    UsuarioRevisionId = table.Column<int>(type: "int", nullable: true),
                    BlSeguimiento = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacitacionCapacitadorSolicitudes", x => x.IdCapacitacionSolicitud);
                });

            migrationBuilder.CreateTable(
                name: "Firmas",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdFirma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    VcFirma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmas", x => x.IdFirma);
                });

            migrationBuilder.CreateTable(
                name: "FormatoPlantillas",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdFormato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VcNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcPlantilla = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormatoPlantillas", x => x.IdFormato);
                });

            migrationBuilder.CreateTable(
                name: "HorariosCapacitacionSolicitudes",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdHonorarios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacitacionSolicitudId = table.Column<int>(type: "int", nullable: false),
                    DtFechaCapacitacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraFin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorariosCapacitacionSolicitudes", x => x.IdHonorarios);
                });

            migrationBuilder.CreateTable(
                name: "ResolucionSolicitudes",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdResolucionSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    TipoResolucionId = table.Column<int>(type: "int", nullable: false),
                    FechaResolucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IntNumeroResolucion = table.Column<int>(type: "int", nullable: false),
                    BlActiva = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResolucionSolicitudes", x => x.IdResolucionSolicitud);
                });

            migrationBuilder.CreateTable(
                name: "SubsanacionSolicitudes",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdSubsanacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    DtFechaSubsanacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VcSubsanacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsanacionSolicitudes", x => x.IdSubsanacion);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancelacionSolicitudes",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "CapacitacionCapacitadorSolicitudes",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "Firmas",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "FormatoPlantillas",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "HorariosCapacitacionSolicitudes",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "ResolucionSolicitudes",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "SubsanacionSolicitudes",
                schema: "manipalimentos");

            migrationBuilder.RenameTable(
                name: "TipoCapacitaciones",
                schema: "manipalimentos",
                newName: "TipoCapacitaciones");

            migrationBuilder.RenameTable(
                name: "Solicitudes",
                schema: "manipalimentos",
                newName: "Solicitudes");

            migrationBuilder.RenameTable(
                name: "SeguimientoAuditoriaSolicitudes",
                schema: "manipalimentos",
                newName: "SeguimientoAuditoriaSolicitudes");

            migrationBuilder.RenameTable(
                name: "ParametroDetalle",
                schema: "manipalimentos",
                newName: "ParametroDetalle");

            migrationBuilder.RenameTable(
                name: "Parametro",
                schema: "manipalimentos",
                newName: "Parametro");

            migrationBuilder.RenameTable(
                name: "Estados",
                schema: "manipalimentos",
                newName: "Estados");

            migrationBuilder.RenameTable(
                name: "DocumentoSolicitudes",
                schema: "manipalimentos",
                newName: "DocumentoSolicitudes");

            migrationBuilder.RenameTable(
                name: "CapacitadorTipoCapacitaciones",
                schema: "manipalimentos",
                newName: "CapacitadorTipoCapacitaciones");

            migrationBuilder.RenameTable(
                name: "CapacitadorSolicitudes",
                schema: "manipalimentos",
                newName: "CapacitadorSolicitudes");
        }
    }
}
