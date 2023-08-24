using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTablaSolicitudTiposolicitante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoSolicitanteId",
                table: "Solicitudes");

            migrationBuilder.AddColumn<string>(
                name: "VcTipoSolicitante",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VcTipoSolicitante",
                table: "Solicitudes");

            migrationBuilder.AddColumn<int>(
                name: "TipoSolicitanteId",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
