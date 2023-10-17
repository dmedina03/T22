using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "manipalimentos");

            migrationBuilder.CreateTable(
                name: "DocumentoSolicitudes",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    VcNombreDocumento = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DtFechaCargue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VcPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntVersion = table.Column<int>(type: "int", nullable: false),
                    BlUsuarioVentanilla = table.Column<bool>(type: "bit", nullable: true),
                    BlIsValid = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoSolicitudes", x => x.IdDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VcTipoEstado = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VcDescripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BlIsEnable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IdEstado);
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
                name: "Parametro",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdParametro = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VcNombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VcCodigoInterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.IdParametro);
                });

            migrationBuilder.CreateTable(
                name: "SpBandejaFuncionarioDto",
                columns: table => new
                {
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VcRadicado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcNombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntNumeroIdentificacionUsuario = table.Column<long>(type: "bigint", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    DtFechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VcTipoEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpBandejaFuncionarioDto", x => x.IdSolicitud);
                });

            migrationBuilder.CreateTable(
                name: "TipoCapacitaciones",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdTipoCapacitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VcDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlIsEnable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCapacitaciones", x => x.IdTipoCapacitacion);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntNumeroIdentificacionUsuario = table.Column<long>(type: "bigint", nullable: false),
                    VcDireccionUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    VcTipoSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioAsignadoValidadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioAsignadoCoordinadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioAsignadoSubdirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DtFechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    ResultadoValidacionId = table.Column<int>(type: "int", nullable: true),
                    VcRadicado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.IdSolicitud);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "manipalimentos",
                        principalTable: "Estados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParametroDetalle",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdParametroDetalle = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPadre = table.Column<long>(type: "bigint", nullable: true),
                    ParametroId = table.Column<long>(type: "bigint", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TxDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcCodigoInterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DCodigoIterno = table.Column<decimal>(type: "decimal(17,3)", precision: 17, scale: 3, nullable: true),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    RangoDesde = table.Column<int>(type: "int", nullable: true),
                    RangoHasta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroDetalle", x => x.IdParametroDetalle);
                    table.ForeignKey(
                        name: "FK_Parametro",
                        column: x => x.ParametroId,
                        principalSchema: "manipalimentos",
                        principalTable: "Parametro",
                        principalColumn: "IdParametro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParametroDetalle_ParametroDetalle_IdPadre",
                        column: x => x.IdPadre,
                        principalSchema: "manipalimentos",
                        principalTable: "ParametroDetalle",
                        principalColumn: "IdParametroDetalle");
                });

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
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelacionSolicitudes", x => x.IdCancelacion);
                    table.ForeignKey(
                        name: "FK_CancelacionSolicitudes_Solicitudes_SolicitudId",
                        column: x => x.SolicitudId,
                        principalSchema: "manipalimentos",
                        principalTable: "Solicitudes",
                        principalColumn: "IdSolicitud",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapacitadorSolicitudes",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdCapacitadorSolicitud = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    VcPrimerNombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VcSegundoNombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VcPrimerApellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VcSegundoApellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoIdentificacionId = table.Column<int>(type: "int", nullable: false),
                    IntNumeroIdentificacion = table.Column<long>(type: "bigint", nullable: false),
                    VcTituloProfesional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vcNumeroTarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntTelefono = table.Column<long>(type: "bigint", nullable: false),
                    VcEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlIsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacitadorSolicitudes", x => x.IdCapacitadorSolicitud);
                    table.ForeignKey(
                        name: "FK_CapacitadorSolicitudes_Solicitudes_SolicitudId",
                        column: x => x.SolicitudId,
                        principalSchema: "manipalimentos",
                        principalTable: "Solicitudes",
                        principalColumn: "IdSolicitud",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResolucionSolicitudes",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdResolucionSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    DocumentoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    TipoResolucionId = table.Column<int>(type: "int", nullable: false),
                    FechaResolucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VcNumeroResolucion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlActiva = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResolucionSolicitudes", x => x.IdResolucionSolicitud);
                    table.ForeignKey(
                        name: "FK_ResolucionSolicitudes_Solicitudes_SolicitudId",
                        column: x => x.SolicitudId,
                        principalSchema: "manipalimentos",
                        principalTable: "Solicitudes",
                        principalColumn: "IdSolicitud",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeguimientoAuditoriaSolicitudes",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdObservacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    DtFechaObservacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VcObservacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientoAuditoriaSolicitudes", x => x.IdObservacion);
                    table.ForeignKey(
                        name: "FK_SeguimientoAuditoriaSolicitudes_Solicitudes_SolicitudId",
                        column: x => x.SolicitudId,
                        principalSchema: "manipalimentos",
                        principalTable: "Solicitudes",
                        principalColumn: "IdSolicitud",
                        onDelete: ReferentialAction.Cascade);
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
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsanacionSolicitudes", x => x.IdSubsanacion);
                    table.ForeignKey(
                        name: "FK_SubsanacionSolicitudes_Solicitudes_SolicitudId",
                        column: x => x.SolicitudId,
                        principalSchema: "manipalimentos",
                        principalTable: "Solicitudes",
                        principalColumn: "IdSolicitud",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapacitacionCapacitadorSolicitudes",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdCapacitacionSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacitadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcPublicoObjetivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntNumeroAsistentes = table.Column<int>(type: "int", nullable: false),
                    VcTemaCapacitacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcMetodologiaCapacitacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtFechaCreacionCapacitacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VcDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcInformacionAdicional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    UsuarioRevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BlSeguimiento = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacitacionCapacitadorSolicitudes", x => x.IdCapacitacionSolicitud);
                    table.ForeignKey(
                        name: "FK_CapacitacionCapacitadorSolicitudes_CapacitadorSolicitudes_CapacitadorId",
                        column: x => x.CapacitadorId,
                        principalSchema: "manipalimentos",
                        principalTable: "CapacitadorSolicitudes",
                        principalColumn: "IdCapacitadorSolicitud",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapacitadorTipoCapacitaciones",
                schema: "manipalimentos",
                columns: table => new
                {
                    IdTipoCapacitacion = table.Column<int>(type: "int", nullable: false),
                    IdCapacitadorSolicitud = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacitadorTipoCapacitaciones", x => new { x.IdTipoCapacitacion, x.IdCapacitadorSolicitud });
                    table.ForeignKey(
                        name: "FK_CapacitadorTipoCapacitaciones_CapacitadorSolicitudes_IdCapacitadorSolicitud",
                        column: x => x.IdCapacitadorSolicitud,
                        principalSchema: "manipalimentos",
                        principalTable: "CapacitadorSolicitudes",
                        principalColumn: "IdCapacitadorSolicitud",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapacitadorTipoCapacitaciones_TipoCapacitaciones_IdTipoCapacitacion",
                        column: x => x.IdTipoCapacitacion,
                        principalSchema: "manipalimentos",
                        principalTable: "TipoCapacitaciones",
                        principalColumn: "IdTipoCapacitacion",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_HorariosCapacitacionSolicitudes_CapacitacionCapacitadorSolicitudes_CapacitacionSolicitudId",
                        column: x => x.CapacitacionSolicitudId,
                        principalSchema: "manipalimentos",
                        principalTable: "CapacitacionCapacitadorSolicitudes",
                        principalColumn: "IdCapacitacionSolicitud",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "manipalimentos",
                table: "Estados",
                columns: new[] { "IdEstado", "BlIsEnable", "VcDescripcion", "VcTipoEstado" },
                values: new object[,]
                {
                    { 1, true, "", "En Revisión" },
                    { 2, true, "", "En Verificación" },
                    { 3, true, "", "Para firma" },
                    { 4, true, "", "Devuelta por coordinador" },
                    { 5, true, "", "Devuelta por Subdirector" },
                    { 6, true, "", "Vencimiento de terminos" },
                    { 7, true, "", "Aprobado" },
                    { 8, true, "", "En Subsanación" },
                    { 9, true, "", "Cancelado" },
                    { 10, true, "", "Negado" },
                    { 11, true, "", "Cancelado por incumplimiento" },
                    { 12, true, "", "Recurso respondido" }
                });

            migrationBuilder.InsertData(
                schema: "manipalimentos",
                table: "TipoCapacitaciones",
                columns: new[] { "IdTipoCapacitacion", "BlIsEnable", "VcDescripcion" },
                values: new object[,]
                {
                    { 1, true, "Carnes y productos cárnicos comestibles" },
                    { 2, true, "Leche cruda" },
                    { 3, true, "Alimentos en vía publica" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CancelacionSolicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "CancelacionSolicitudes",
                column: "SolicitudId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CapacitacionCapacitadorSolicitudes_CapacitadorId",
                schema: "manipalimentos",
                table: "CapacitacionCapacitadorSolicitudes",
                column: "CapacitadorId");

            migrationBuilder.CreateIndex(
                name: "IX_CapacitadorSolicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "CapacitadorSolicitudes",
                column: "SolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_CapacitadorTipoCapacitaciones_IdCapacitadorSolicitud",
                schema: "manipalimentos",
                table: "CapacitadorTipoCapacitaciones",
                column: "IdCapacitadorSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_HorariosCapacitacionSolicitudes_CapacitacionSolicitudId",
                schema: "manipalimentos",
                table: "HorariosCapacitacionSolicitudes",
                column: "CapacitacionSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroDetalle_IdPadre",
                schema: "manipalimentos",
                table: "ParametroDetalle",
                column: "IdPadre");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroDetalle_ParametroId",
                schema: "manipalimentos",
                table: "ParametroDetalle",
                column: "ParametroId");

            migrationBuilder.CreateIndex(
                name: "IX_ResolucionSolicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "ResolucionSolicitudes",
                column: "SolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientoAuditoriaSolicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "SeguimientoAuditoriaSolicitudes",
                column: "SolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_EstadoId",
                schema: "manipalimentos",
                table: "Solicitudes",
                column: "EstadoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubsanacionSolicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "SubsanacionSolicitudes",
                column: "SolicitudId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancelacionSolicitudes",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "CapacitadorTipoCapacitaciones",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "DocumentoSolicitudes",
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
                name: "ParametroDetalle",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "ResolucionSolicitudes",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "SeguimientoAuditoriaSolicitudes",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "SpBandejaFuncionarioDto");

            migrationBuilder.DropTable(
                name: "SubsanacionSolicitudes",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "TipoCapacitaciones",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "CapacitacionCapacitadorSolicitudes",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "Parametro",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "CapacitadorSolicitudes",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "Solicitudes",
                schema: "manipalimentos");

            migrationBuilder.DropTable(
                name: "Estados",
                schema: "manipalimentos");
        }
    }
}
