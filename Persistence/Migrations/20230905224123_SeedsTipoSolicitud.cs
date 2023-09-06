using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedsTipoSolicitud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 1L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 5, 17, 41, 23, 91, DateTimeKind.Local).AddTicks(8935), new DateTime(2023, 9, 5, 17, 41, 23, 91, DateTimeKind.Local).AddTicks(8921) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 2L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 5, 17, 41, 23, 91, DateTimeKind.Local).AddTicks(8957), new DateTime(2023, 9, 5, 17, 41, 23, 91, DateTimeKind.Local).AddTicks(8946) });

            migrationBuilder.InsertData(
                schema: "manipalimentos",
                table: "Parametro",
                columns: new[] { "IdParametro", "BEstado", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "VcCodigoInterno", "VcNombre" },
                values: new object[] { 3L, true, new DateTime(2023, 9, 5, 17, 41, 23, 91, DateTimeKind.Local).AddTicks(8958), null, new DateTime(2023, 9, 5, 17, 41, 23, 91, DateTimeKind.Local).AddTicks(8958), "bTipoSolicitud", "Tipo de solicitud" });

            migrationBuilder.InsertData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                columns: new[] { "IdParametroDetalle", "BEstado", "DCodigoIterno", "IdPadre", "ParametroId", "RangoDesde", "RangoHasta", "TxDescripcion", "VcCodigoInterno", "VcNombre" },
                values: new object[,]
                {
                    { 11L, true, 0m, null, 3L, 0, 0, "", "", "Primera vez" },
                    { 12L, true, 0m, null, 3L, 0, 0, "", "", "Renovación" },
                    { 13L, true, 0m, null, 3L, 0, 0, "", "", "Modificación" },
                    { 14L, true, 0m, null, 3L, 0, 0, "", "", "Recurso de reposición" },
                    { 15L, true, 0m, null, 3L, 0, 0, "", "", "Cancelación" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 1L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 5, 17, 24, 1, 231, DateTimeKind.Local).AddTicks(5316), new DateTime(2023, 9, 5, 17, 24, 1, 231, DateTimeKind.Local).AddTicks(5306) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 2L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 5, 17, 24, 1, 231, DateTimeKind.Local).AddTicks(5320), new DateTime(2023, 9, 5, 17, 24, 1, 231, DateTimeKind.Local).AddTicks(5319) });
        }
    }
}
