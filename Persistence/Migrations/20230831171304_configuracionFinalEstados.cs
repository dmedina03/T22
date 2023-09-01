using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class configuracionFinalEstados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Estados",
                keyColumn: "IdEstado",
                keyValue: 9,
                column: "VcTipoEstado",
                value: "Cancelado");

            migrationBuilder.InsertData(
                schema: "manipalimentos",
                table: "Estados",
                columns: new[] { "IdEstado", "BlIsEnable", "VcDescripcion", "VcTipoEstado" },
                values: new object[] { 11, true, "", "Cancelado por incumplimiento" });

            migrationBuilder.CreateIndex(
                name: "IX_SubsanacionSolicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "SubsanacionSolicitudes",
                column: "SolicitudId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CancelacionSolicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "CancelacionSolicitudes",
                column: "SolicitudId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CancelacionSolicitudes_Solicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "CancelacionSolicitudes",
                column: "SolicitudId",
                principalSchema: "manipalimentos",
                principalTable: "Solicitudes",
                principalColumn: "IdSolicitud",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubsanacionSolicitudes_Solicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "SubsanacionSolicitudes",
                column: "SolicitudId",
                principalSchema: "manipalimentos",
                principalTable: "Solicitudes",
                principalColumn: "IdSolicitud",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CancelacionSolicitudes_Solicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "CancelacionSolicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_SubsanacionSolicitudes_Solicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "SubsanacionSolicitudes");

            migrationBuilder.DropIndex(
                name: "IX_SubsanacionSolicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "SubsanacionSolicitudes");

            migrationBuilder.DropIndex(
                name: "IX_CancelacionSolicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "CancelacionSolicitudes");

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "Estados",
                keyColumn: "IdEstado",
                keyValue: 11);

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Estados",
                keyColumn: "IdEstado",
                keyValue: 9,
                column: "VcTipoEstado",
                value: "Anulado");
        }
    }
}
