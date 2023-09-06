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
            migrationBuilder.CreateTable(
                name: "DocumentoSolicitud",
                columns: table => new
                {
                    IdDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    VcNombreDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtFechaCargue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VcPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntVersion = table.Column<int>(type: "int", nullable: false),
                    BlUsuarioVentanilla = table.Column<bool>(type: "bit", nullable: false),
                    BlIsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoSolicitud", x => x.IdDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VcTipoEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlIsEnable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "Parametro",
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
                name: "TipoCapacitacion",
                columns: table => new
                {
                    IdTipoCapacitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VcDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlIsEnable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCapacitacion", x => x.IdTipoCapacitacion);
                });

            migrationBuilder.CreateTable(
                name: "Solicitud",
                columns: table => new
                {
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TipoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    TipoSolicitanteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioAsignadoId = table.Column<int>(type: "int", nullable: false),
                    DtFechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    VcRadicado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud", x => x.IdSolicitud);
                    table.ForeignKey(
                        name: "FK_Solicitud_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParametroDetalle",
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
                        principalTable: "Parametro",
                        principalColumn: "IdParametro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParametroDetalle_ParametroDetalle_IdPadre",
                        column: x => x.IdPadre,
                        principalTable: "ParametroDetalle",
                        principalColumn: "IdParametroDetalle");
                });

            migrationBuilder.CreateTable(
                name: "CapacitadorSolicitud",
                columns: table => new
                {
                    IdCapacitadorSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    VcPrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcSegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcPrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcSegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoIdentificacionId = table.Column<int>(type: "int", nullable: false),
                    IntNumeroIdentificacion = table.Column<long>(type: "bigint", nullable: false),
                    VcTituloProfesional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vcNumeroTarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntTelefono = table.Column<int>(type: "int", nullable: false),
                    VcEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlIsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacitadorSolicitud", x => x.IdCapacitadorSolicitud);
                    table.ForeignKey(
                        name: "FK_CapacitadorSolicitud_Solicitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitud",
                        principalColumn: "IdSolicitud",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeguimientoAuditoriaSolicitud",
                columns: table => new
                {
                    IdObservacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    DtFechaObservacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VcObservacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    VcNombreUsuario = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientoAuditoriaSolicitud", x => x.IdObservacion);
                    table.ForeignKey(
                        name: "FK_SeguimientoAuditoriaSolicitud_Solicitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitud",
                        principalColumn: "IdSolicitud",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapacitadorTipoCapacitacion",
                columns: table => new
                {
                    IdTipoCapacitacion = table.Column<int>(type: "int", nullable: false),
                    IdCapacitadorSolicitud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacitadorTipoCapacitacion", x => new { x.IdTipoCapacitacion, x.IdCapacitadorSolicitud });
                    table.ForeignKey(
                        name: "FK_CapacitadorTipoCapacitacion_CapacitadorSolicitud_IdCapacitadorSolicitud",
                        column: x => x.IdCapacitadorSolicitud,
                        principalTable: "CapacitadorSolicitud",
                        principalColumn: "IdCapacitadorSolicitud",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapacitadorTipoCapacitacion_TipoCapacitacion_IdTipoCapacitacion",
                        column: x => x.IdTipoCapacitacion,
                        principalTable: "TipoCapacitacion",
                        principalColumn: "IdTipoCapacitacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "IdEstado", "BlIsEnable", "VcDescripcion", "VcTipoEstado" },
                values: new object[] { 1, true, "Prueba", "Prueba" });

            migrationBuilder.InsertData(
                table: "TipoCapacitacion",
                columns: new[] { "IdTipoCapacitacion", "BlIsEnable", "VcDescripcion" },
                values: new object[,]
                {
                    { 1, true, "Carnes y productos cárnicos comestibles" },
                    { 2, true, "Leche cruda" },
                    { 3, true, "Alimentos en vía publica" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapacitadorSolicitud_SolicitudId",
                table: "CapacitadorSolicitud",
                column: "SolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_CapacitadorTipoCapacitacion_IdCapacitadorSolicitud",
                table: "CapacitadorTipoCapacitacion",
                column: "IdCapacitadorSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroDetalle_IdPadre",
                table: "ParametroDetalle",
                column: "IdPadre");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroDetalle_ParametroId",
                table: "ParametroDetalle",
                column: "ParametroId");

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientoAuditoriaSolicitud_SolicitudId",
                table: "SeguimientoAuditoriaSolicitud",
                column: "SolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_EstadoId",
                table: "Solicitud",
                column: "EstadoId",
                unique: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapacitadorTipoCapacitacion");

            migrationBuilder.DropTable(
                name: "DocumentoSolicitud");

            migrationBuilder.DropTable(
                name: "ParametroDetalle");

            migrationBuilder.DropTable(
                name: "SeguimientoAuditoriaSolicitud");

            migrationBuilder.DropTable(
                name: "CapacitadorSolicitud");

            migrationBuilder.DropTable(
                name: "TipoCapacitacion");

            migrationBuilder.DropTable(
                name: "Parametro");

            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
