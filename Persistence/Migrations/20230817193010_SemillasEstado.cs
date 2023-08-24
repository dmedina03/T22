using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SemillasEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResultadoValidacionId",
                table: "Solicitud",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "IdEstado",
                keyValue: 1,
                columns: new[] { "VcDescripcion", "VcTipoEstado" },
                values: new object[] { "", "En Revisión" });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "IdEstado", "BlIsEnable", "VcDescripcion", "VcTipoEstado" },
                values: new object[,]
                {
                    { 2, true, "", "En Verificación" },
                    { 3, true, "", "Para firma" },
                    { 4, true, "", "Devuelta por coordinador" },
                    { 5, true, "", "Devuelta por Subdirector" },
                    { 6, true, "", "Vencimiento de terminos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "IdEstado",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "IdEstado",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "IdEstado",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "IdEstado",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "IdEstado",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "ResultadoValidacionId",
                table: "Solicitud");

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "IdEstado",
                keyValue: 1,
                columns: new[] { "VcDescripcion", "VcTipoEstado" },
                values: new object[] { "Prueba", "Prueba" });
        }
    }
}
