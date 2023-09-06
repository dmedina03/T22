using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "IntNumeroResolucion",
                schema: "manipalimentos",
                table: "ResolucionSolicitudes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                schema: "manipalimentos",
                table: "Parametro",
                columns: new[] { "IdParametro", "BEstado", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "VcCodigoInterno", "VcNombre" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(2023, 9, 5, 17, 24, 1, 231, DateTimeKind.Local).AddTicks(5316), null, new DateTime(2023, 9, 5, 17, 24, 1, 231, DateTimeKind.Local).AddTicks(5306), "bTipoResolucion", "Tipo resolución" },
                    { 2L, true, new DateTime(2023, 9, 5, 17, 24, 1, 231, DateTimeKind.Local).AddTicks(5320), null, new DateTime(2023, 9, 5, 17, 24, 1, 231, DateTimeKind.Local).AddTicks(5319), "bResultadoValidacion", "Resultado de la validación" }
                });

            migrationBuilder.InsertData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                columns: new[] { "IdParametroDetalle", "BEstado", "DCodigoIterno", "IdPadre", "ParametroId", "RangoDesde", "RangoHasta", "TxDescripcion", "VcCodigoInterno", "VcNombre" },
                values: new object[,]
                {
                    { 1L, true, 0m, null, 1L, 0, 0, "", "", "Resolución de aprobación" },
                    { 2L, true, 0m, null, 1L, 0, 0, "", "", "Resolución de cancelación" },
                    { 3L, true, 0m, null, 1L, 0, 0, "", "", "Resolución de negación" },
                    { 4L, true, 0m, null, 1L, 0, 0, "", "", "Resolución de modificación" },
                    { 5L, true, 0m, null, 1L, 0, 0, "", "", "Resolución de cancelación por incumplimiento" },
                    { 6L, true, 0m, null, 2L, 0, 0, "Aprobación", "", "Aprobar solicitud" },
                    { 7L, true, 0m, null, 2L, 0, 0, "Cancelación", "", "Cancelar solicitud" },
                    { 8L, true, 0m, null, 2L, 0, 0, "Negación", "", "Negar solicitud" },
                    { 9L, true, 0m, null, 2L, 0, 0, "Subsanación", "", "Para Subsanación" },
                    { 10L, true, 0m, null, 2L, 0, 0, "Cancelación por incumplimiento", "", "Cancelar por incumplimiento" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 2L);

            migrationBuilder.AlterColumn<int>(
                name: "IntNumeroResolucion",
                schema: "manipalimentos",
                table: "ResolucionSolicitudes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
