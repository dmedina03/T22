using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguracionResolucion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentoSolicitudId",
                schema: "manipalimentos",
                table: "ResolucionSolicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResolucionSolicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "ResolucionSolicitudes",
                column: "SolicitudId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResolucionSolicitudes_Solicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "ResolucionSolicitudes",
                column: "SolicitudId",
                principalSchema: "manipalimentos",
                principalTable: "Solicitudes",
                principalColumn: "IdSolicitud",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResolucionSolicitudes_Solicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "ResolucionSolicitudes");

            migrationBuilder.DropIndex(
                name: "IX_ResolucionSolicitudes_SolicitudId",
                schema: "manipalimentos",
                table: "ResolucionSolicitudes");

            migrationBuilder.DropColumn(
                name: "DocumentoSolicitudId",
                schema: "manipalimentos",
                table: "ResolucionSolicitudes");
        }
    }
}
