using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNombreTablasDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CapacitadorSolicitud_Solicitud_SolicitudId",
                table: "CapacitadorSolicitud");

            migrationBuilder.DropForeignKey(
                name: "FK_CapacitadorTipoCapacitacion_CapacitadorSolicitud_IdCapacitadorSolicitud",
                table: "CapacitadorTipoCapacitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_CapacitadorTipoCapacitacion_TipoCapacitacion_IdTipoCapacitacion",
                table: "CapacitadorTipoCapacitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_SeguimientoAuditoriaSolicitud_Solicitud_SolicitudId",
                table: "SeguimientoAuditoriaSolicitud");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_Estado_EstadoId",
                table: "Solicitud");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoCapacitacion",
                table: "TipoCapacitacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solicitud",
                table: "Solicitud");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeguimientoAuditoriaSolicitud",
                table: "SeguimientoAuditoriaSolicitud");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estado",
                table: "Estado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentoSolicitud",
                table: "DocumentoSolicitud");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CapacitadorTipoCapacitacion",
                table: "CapacitadorTipoCapacitacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CapacitadorSolicitud",
                table: "CapacitadorSolicitud");

            migrationBuilder.RenameTable(
                name: "TipoCapacitacion",
                newName: "TipoCapacitaciones");

            migrationBuilder.RenameTable(
                name: "Solicitud",
                newName: "Solicitudes");

            migrationBuilder.RenameTable(
                name: "SeguimientoAuditoriaSolicitud",
                newName: "SeguimientoAuditoriaSolicitudes");

            migrationBuilder.RenameTable(
                name: "Estado",
                newName: "Estados");

            migrationBuilder.RenameTable(
                name: "DocumentoSolicitud",
                newName: "DocumentoSolicitudes");

            migrationBuilder.RenameTable(
                name: "CapacitadorTipoCapacitacion",
                newName: "CapacitadorTipoCapacitaciones");

            migrationBuilder.RenameTable(
                name: "CapacitadorSolicitud",
                newName: "CapacitadorSolicitudes");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitud_EstadoId",
                table: "Solicitudes",
                newName: "IX_Solicitudes_EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_SeguimientoAuditoriaSolicitud_SolicitudId",
                table: "SeguimientoAuditoriaSolicitudes",
                newName: "IX_SeguimientoAuditoriaSolicitudes_SolicitudId");

            migrationBuilder.RenameIndex(
                name: "IX_CapacitadorTipoCapacitacion_IdCapacitadorSolicitud",
                table: "CapacitadorTipoCapacitaciones",
                newName: "IX_CapacitadorTipoCapacitaciones_IdCapacitadorSolicitud");

            migrationBuilder.RenameIndex(
                name: "IX_CapacitadorSolicitud_SolicitudId",
                table: "CapacitadorSolicitudes",
                newName: "IX_CapacitadorSolicitudes_SolicitudId");

            migrationBuilder.AddColumn<int>(
                name: "IntNumeroIdentificacionUsuario",
                table: "Solicitudes",
                type: "bigint",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VcNombreUsuario",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "IntTelefono",
                table: "CapacitadorSolicitudes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoCapacitaciones",
                table: "TipoCapacitaciones",
                column: "IdTipoCapacitacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solicitudes",
                table: "Solicitudes",
                column: "IdSolicitud");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeguimientoAuditoriaSolicitudes",
                table: "SeguimientoAuditoriaSolicitudes",
                column: "IdObservacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estados",
                table: "Estados",
                column: "IdEstado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentoSolicitudes",
                table: "DocumentoSolicitudes",
                column: "IdDocumento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CapacitadorTipoCapacitaciones",
                table: "CapacitadorTipoCapacitaciones",
                columns: new[] { "IdTipoCapacitacion", "IdCapacitadorSolicitud" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CapacitadorSolicitudes",
                table: "CapacitadorSolicitudes",
                column: "IdCapacitadorSolicitud");

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "IdEstado", "BlIsEnable", "VcDescripcion", "VcTipoEstado" },
                values: new object[,]
                {
                    { 7, true, "", "Aprobado" },
                    { 8, true, "", "En Subsanación" },
                    { 9, true, "", "Anulado" },
                    { 10, true, "", "Negado" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CapacitadorSolicitudes_Solicitudes_SolicitudId",
                table: "CapacitadorSolicitudes",
                column: "SolicitudId",
                principalTable: "Solicitudes",
                principalColumn: "IdSolicitud",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CapacitadorTipoCapacitaciones_CapacitadorSolicitudes_IdCapacitadorSolicitud",
                table: "CapacitadorTipoCapacitaciones",
                column: "IdCapacitadorSolicitud",
                principalTable: "CapacitadorSolicitudes",
                principalColumn: "IdCapacitadorSolicitud",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CapacitadorTipoCapacitaciones_TipoCapacitaciones_IdTipoCapacitacion",
                table: "CapacitadorTipoCapacitaciones",
                column: "IdTipoCapacitacion",
                principalTable: "TipoCapacitaciones",
                principalColumn: "IdTipoCapacitacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeguimientoAuditoriaSolicitudes_Solicitudes_SolicitudId",
                table: "SeguimientoAuditoriaSolicitudes",
                column: "SolicitudId",
                principalTable: "Solicitudes",
                principalColumn: "IdSolicitud",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Estados_EstadoId",
                table: "Solicitudes",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CapacitadorSolicitudes_Solicitudes_SolicitudId",
                table: "CapacitadorSolicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_CapacitadorTipoCapacitaciones_CapacitadorSolicitudes_IdCapacitadorSolicitud",
                table: "CapacitadorTipoCapacitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_CapacitadorTipoCapacitaciones_TipoCapacitaciones_IdTipoCapacitacion",
                table: "CapacitadorTipoCapacitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_SeguimientoAuditoriaSolicitudes_Solicitudes_SolicitudId",
                table: "SeguimientoAuditoriaSolicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Estados_EstadoId",
                table: "Solicitudes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoCapacitaciones",
                table: "TipoCapacitaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solicitudes",
                table: "Solicitudes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeguimientoAuditoriaSolicitudes",
                table: "SeguimientoAuditoriaSolicitudes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estados",
                table: "Estados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentoSolicitudes",
                table: "DocumentoSolicitudes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CapacitadorTipoCapacitaciones",
                table: "CapacitadorTipoCapacitaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CapacitadorSolicitudes",
                table: "CapacitadorSolicitudes");

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "IdEstado",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "IdEstado",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "IdEstado",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "IdEstado",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "IntNumeroIdentificacionUsuario",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "VcNombreUsuario",
                table: "Solicitudes");

            migrationBuilder.RenameTable(
                name: "TipoCapacitaciones",
                newName: "TipoCapacitacion");

            migrationBuilder.RenameTable(
                name: "Solicitudes",
                newName: "Solicitud");

            migrationBuilder.RenameTable(
                name: "SeguimientoAuditoriaSolicitudes",
                newName: "SeguimientoAuditoriaSolicitud");

            migrationBuilder.RenameTable(
                name: "Estados",
                newName: "Estado");

            migrationBuilder.RenameTable(
                name: "DocumentoSolicitudes",
                newName: "DocumentoSolicitud");

            migrationBuilder.RenameTable(
                name: "CapacitadorTipoCapacitaciones",
                newName: "CapacitadorTipoCapacitacion");

            migrationBuilder.RenameTable(
                name: "CapacitadorSolicitudes",
                newName: "CapacitadorSolicitud");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitudes_EstadoId",
                table: "Solicitud",
                newName: "IX_Solicitud_EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_SeguimientoAuditoriaSolicitudes_SolicitudId",
                table: "SeguimientoAuditoriaSolicitud",
                newName: "IX_SeguimientoAuditoriaSolicitud_SolicitudId");

            migrationBuilder.RenameIndex(
                name: "IX_CapacitadorTipoCapacitaciones_IdCapacitadorSolicitud",
                table: "CapacitadorTipoCapacitacion",
                newName: "IX_CapacitadorTipoCapacitacion_IdCapacitadorSolicitud");

            migrationBuilder.RenameIndex(
                name: "IX_CapacitadorSolicitudes_SolicitudId",
                table: "CapacitadorSolicitud",
                newName: "IX_CapacitadorSolicitud_SolicitudId");

            migrationBuilder.AlterColumn<int>(
                name: "IntTelefono",
                table: "CapacitadorSolicitud",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoCapacitacion",
                table: "TipoCapacitacion",
                column: "IdTipoCapacitacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solicitud",
                table: "Solicitud",
                column: "IdSolicitud");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeguimientoAuditoriaSolicitud",
                table: "SeguimientoAuditoriaSolicitud",
                column: "IdObservacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estado",
                table: "Estado",
                column: "IdEstado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentoSolicitud",
                table: "DocumentoSolicitud",
                column: "IdDocumento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CapacitadorTipoCapacitacion",
                table: "CapacitadorTipoCapacitacion",
                columns: new[] { "IdTipoCapacitacion", "IdCapacitadorSolicitud" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CapacitadorSolicitud",
                table: "CapacitadorSolicitud",
                column: "IdCapacitadorSolicitud");

            migrationBuilder.AddForeignKey(
                name: "FK_CapacitadorSolicitud_Solicitud_SolicitudId",
                table: "CapacitadorSolicitud",
                column: "SolicitudId",
                principalTable: "Solicitud",
                principalColumn: "IdSolicitud",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CapacitadorTipoCapacitacion_CapacitadorSolicitud_IdCapacitadorSolicitud",
                table: "CapacitadorTipoCapacitacion",
                column: "IdCapacitadorSolicitud",
                principalTable: "CapacitadorSolicitud",
                principalColumn: "IdCapacitadorSolicitud",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CapacitadorTipoCapacitacion_TipoCapacitacion_IdTipoCapacitacion",
                table: "CapacitadorTipoCapacitacion",
                column: "IdTipoCapacitacion",
                principalTable: "TipoCapacitacion",
                principalColumn: "IdTipoCapacitacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeguimientoAuditoriaSolicitud_Solicitud_SolicitudId",
                table: "SeguimientoAuditoriaSolicitud",
                column: "SolicitudId",
                principalTable: "Solicitud",
                principalColumn: "IdSolicitud",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_Estado_EstadoId",
                table: "Solicitud",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
